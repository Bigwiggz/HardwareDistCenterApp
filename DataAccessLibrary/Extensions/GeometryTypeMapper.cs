using Dapper;
using NetTopologySuite.Geometries;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Extensions
{
    public class GeometryTypeMapper : SqlMapper.TypeHandler<Geometry>
    {
        public override void SetValue(IDbDataParameter parameter, Geometry value)
        {
            if (parameter is NpgsqlParameter npgsqlParameter)
            {
                npgsqlParameter.NpgsqlDbType = NpgsqlDbType.Geometry;
                npgsqlParameter.NpgsqlValue = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override Geometry Parse(object value)
        {
            if (value is Geometry geometry)
            {
                return geometry;
            }

            throw new ArgumentException();
        }
    }
}
