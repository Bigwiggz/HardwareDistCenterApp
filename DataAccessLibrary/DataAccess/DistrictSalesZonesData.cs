using DataAccessLibrary.Internal;
using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public class DistrictSalesZonesData : IDistrictSalesZonesData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<DistrictSalesZones> _logger;
        private readonly ISqlQueries _sqlQuery;

        public DistrictSalesZonesData(ISqlDataAccess sql, ILogger<DistrictSalesZones> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["DistrictSalesZonesDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted form DistrictSalesZones Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<DistrictSalesZones>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["DistrictSalesZonesGetAllAsync"];
            var result = await _sql.LoadData<DistrictSalesZones, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<DistrictSalesZones> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["DistrictSalesZonesGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<DistrictSalesZones, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(DistrictSalesZones model)
        {
            string sqlString = _sqlQuery.sqlQueries["DistrictSalesZonesInsertAsync"];

            var p = new
            {
                DistrictSalesZoneID = model.DistrictSalesZoneID,
                DistrictManagerID = model.DistrictManagerID,
                DistrictSalesZoneName = model.DistrictSalesZoneName,
                DistrictSalesZoneNumber = model.DistrictSalesZoneNumber,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(DistrictSalesZones model)
        {
            string sqlString = _sqlQuery.sqlQueries["DistrictSalesZonesUpdateByIdAsync"];
            var p = new
            {
                DistrictSalesZoneID = model.DistrictSalesZoneID,
                DistrictManagerID = model.DistrictManagerID,
                DistrictSalesZoneName = model.DistrictSalesZoneName,
                DistrictSalesZoneNumber = model.DistrictSalesZoneNumber,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
