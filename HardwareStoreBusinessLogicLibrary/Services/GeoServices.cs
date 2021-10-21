using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;


namespace HardwareStoreBusinessLogicLibrary.Services
{
    public class GeoServices
    {
        public GeoServices()
        {

        }

        public NetTopologySuite.Geometries.Geometry CreateNTSGeometryFromGeometryGeoJSONObject<T>(T geometry)
        {
            var geometryTextGeoJSON=JsonSerializer.Serialize(geometry);

            var serializer=GeoJsonSerializer.Create();
            //TODO: May need to add Json Serializer Converter  go to https://docs.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonconverter-1?view=net-5.0
            using(var stringReader=new StringReader(geometryTextGeoJSON))
            using(var jsonReader=new JsonTextReader(stringReader))
            {
                geometry=serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}