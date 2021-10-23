//////////////////////////////////////////
//Zone Distribution Centers JS File
//////////////////////////////////////////

///////////////////////////////////////////
//Create Map with coordinates
///////////////////////////////////////////
let map = L.map('map');

///////////////////////////////////////////
//Create Global Variables
///////////////////////////////////////////


//used to filter list on input
let filteredDistributionCentersList={};


///////////////////////////////////////////
//Add Map Layers
///////////////////////////////////////////


let googleStreets = L.tileLayer('http://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}',{
    maxZoom: 20,
    subdomains:['mt0','mt1','mt2','mt3']
});

let googleHybrid = L.tileLayer('http://{s}.google.com/vt/lyrs=s,h&x={x}&y={y}&z={z}',{
    maxZoom: 20,
    subdomains:['mt0','mt1','mt2','mt3']
});

let googleSat = L.tileLayer('http://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}',{
    maxZoom: 20,
    subdomains:['mt0','mt1','mt2','mt3']
});

let googleTerrain = L.tileLayer('http://{s}.google.com/vt/lyrs=p&x={x}&y={y}&z={z}',{
    maxZoom: 20,
    subdomains:['mt0','mt1','mt2','mt3']
});

let osm=L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
})

let greyblank= L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/Canvas/World_Light_Gray_Base/MapServer/tile/{z}/{y}/{x}', {
	attribution: 'Tiles &copy; Esri &mdash; Esri, DeLorme, NAVTEQ',
	maxZoom: 16
});

let blockMap= L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer/tile/{z}/{y}/{x}', {
	attribution: 'Tiles &copy; Esri &mdash; Source: Esri, DeLorme, NAVTEQ, USGS, Intermap, iPC, NRCAN, Esri Japan, METI, Esri China (Hong Kong), Esri (Thailand), TomTom, 2012'
});

googleStreets.addTo(map);

//import list of locations
filteredDistributionCentersList=getDataCenterGeoJSON;


//Add scale to map
L.control.scale({position: 'bottomright'}).addTo(map);


///////////////////////////////////////////
//Add DistributionCentersList
///////////////////////////////////////////
let distributionCentersMappedLocations=L.geoJSON(filteredDistributionCentersList,{
	style:function(feature){
		return{
			color: "#70003a",
			fillColor: "#70003a",
			fill:true,
			fillOpacity: 0.2
		}
	},
	onEachFeature:function(feature, layer){
		layer.bindTooltip(feature.properties.zoneDistributionCenterCode,{
			permanent:true,
			direction:"center",
			className:"distributionCenterLabel"
		});
		layer.on('click',function(){
			let polygonProperties=feature.properties;
			LoadItemInformation(polygonProperties);
		});
	}
});

//Add Default Layer to Map
distributionCentersMappedLocations.addTo(map);
//bound to layer set
map.fitBounds(distributionCentersMappedLocations.getBounds(),{padding: [10,10]});

///////////////////////////////////////////
//Create Layer Groups
///////////////////////////////////////////



///////////////////////////////////////////
//Add Map Layer Controller
///////////////////////////////////////////

//Base Maps to Layer
let baseMaps={
	"Google Streets": googleStreets,
	"Google Satelite":googleSat,
	"Google Hybrid":googleHybrid,
	"Open St Maps": osm,
	"Block Map": blockMap,
	"Gray": greyblank
};

//Shapes to Layer
let overlayMaps={
	"Distribution Centers":distributionCentersMappedLocations,
};

L.control.layers(baseMaps,overlayMaps).addTo(map);




///////////////////////////////////////////
//Function to add input information
///////////////////////////////////////////

function LoadItemInformation(properties){
	
	
	//Append html table information
	const InformationTable=document.getElementById("InformationTableBody");
	InformationTable.textContent="";

	let htmlTable="";
	
	for (var key of Object.keys(properties)) {
		let columnField=key.replace(/([A-Z])/g, ' $1').trim();
		let columnValue=properties[key];
		
		htmlTable+=
		`
		<tr>
			<td><b>${columnField}</b></td>
			<td>${columnValue}</td>
		</tr>
		`
	}
	
	//Append html table information
	InformationTable.insertAdjacentHTML('afterbegin',htmlTable);

	//turn visibility of element on to display table
	document.getElementById("table-information-section").style.visibility="visible";

	//clear input array after information is posted
	result=[];
	
	//scroll to Item Information Table
	document.getElementById("table-information-section").scrollIntoView();
	
}
 
///////////////////////////////////////////
//Add Leaflet Drawing Controls 
///////////////////////////////////////////

map.on('pm:create', e => {
  generateGeoJson();
  ClearAllDrawingLayers();
});


map.pm.addControls({  
  position: 'topleft',
  editMode: true,
  removalMode: true,
  drawMarker:true,
  drawPolygon:true,
  drawRectangle:false,
  drawCircle:false,
  drawCircleMarker:false
});




/*
Function to get geoJSON after shape has been created

map.on('pm:create',(e) {
  e.layer.on('pm:edit', ({ layer }) => {
    // layer has been edited
    console.log(layer.toGeoJSON());
  })
});
*/

/*
Function to clear all shapes


map.eachLayer(function(layer){
     if (layer._path != null) {
    layer.remove()
  }
});

*/


function ClearAllDrawingLayers(){
	map.eachLayer(function(layer){
     if (layer._path != null) {
    layer.remove()
	  }
	});
};


function generateGeoJson(){
	var fg = L.featureGroup();    
	var layers = findLayers(map);
  layers.forEach(function(layer){
  	fg.addLayer(layer);
  });
	LoadTerritoryJSONText(fg);
	console.log(fg.toGeoJSON());
}

function findLayers(map) {
    var layers = [];
    map.eachLayer(layer => {
      if (
        layer instanceof L.Polyline ||
        layer instanceof L.Marker ||
        layer instanceof L.Circle ||
        layer instanceof L.CircleMarker
      ) {
        layers.push(layer);
      }
    });

    // filter out layers that don't have the leaflet-geoman instance
    layers = layers.filter(layer => !!layer.pm);

    // filter out everything that's leaflet-geoman specific temporary stuff
    layers = layers.filter(layer => !layer._pmTempLayer);

    return layers;
};