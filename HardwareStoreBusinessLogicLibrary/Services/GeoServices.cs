using NetTopologySuite.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;


namespace HardwareStoreBusinessLogicLibrary.Services
{
    public class GeoServices
    {
        public GeoServices()
        {

        }

        public NetTopologySuite.Geometries.Geometry CreateNTSGeometryFromGeometryGeoJSONObject<T>(T geometryObject)
        {
            string geoJsonString = System.Text.Json.JsonSerializer.Serialize(geometryObject);

            var geoJsonOptions = new JsonSerializerOptions();
            geoJsonOptions.Converters.Add(new NetTopologySuite.IO.Converters.GeoJsonConverterFactory());
            var serializer = GeoJsonSerializer.Create();
            NetTopologySuite.Geometries.Geometry geoShape;
            using (var stringReader = new StringReader(geoJsonString))
            {
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    geoShape = serializer.Deserialize<NetTopologySuite.Geometries.Geometry>(jsonReader);
                }
            }
            return geoShape;
        }
    }
}