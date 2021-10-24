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
    public class ZoneDistributionCenterData : IZoneDistributionCenterData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<ZoneDistributionCenters> _logger;
        private readonly ISqlQueries _sqlQuery;

        public ZoneDistributionCenterData(ISqlDataAccess sql, ILogger<ZoneDistributionCenters> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["ZoneDistributionCenterDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from ZoneDistributionCenters Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<ZoneDistributionCenters>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["ZoneDistributionCentersGetAllAsync"];
            var result = await _sql.LoadData<ZoneDistributionCenters, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<ZoneDistributionCenters> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["ZoneDistributionCentersGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<ZoneDistributionCenters, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(ZoneDistributionCenters model)
        {
            string sqlString = _sqlQuery.sqlQueries["ZoneDistributionCenterInsertAsync"];

            var p = new
            {
                ZoneDistributionCenterID = model.ZoneDistributionCenterID,
                ZoneDistributionCenterLocation = model.ZoneDistributionCenterLocation,
                ZoneDistributionCenterStreet = model.ZoneDistributionCenterStreet,
                ZoneDistributionCenterCity = model.ZoneDistributionCenterCity,
                ZoneDistributionCenterState = model.ZoneDistributionCenterState,
                ZoneDistributionCenterZipCode = model.ZoneDistributionCenterZipCode,
                ZoneDistributionCenterCountryCode = model.ZoneDistributionCenterCountryCode,
                ZoneDistributionCenterCode = model.ZoneDistributionCenterCode,
                ActiveStatus = model.ActiveStatus,
                fkDistrictSalesZoneID = model.fkDistrictSalesZoneID
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(ZoneDistributionCenters model)
        {
            string sqlString = _sqlQuery.sqlQueries["ZoneDistributionCenterUpdateByIdAsync"];
            var p = new
            {
                ZoneDistributionCenterID = model.ZoneDistributionCenterID,
                ZoneDistributionCenterLocation = model.ZoneDistributionCenterLocation,
                ZoneDistributionCenterStreet = model.ZoneDistributionCenterStreet,
                ZoneDistributionCenterCity = model.ZoneDistributionCenterCity,
                ZoneDistributionCenterState = model.ZoneDistributionCenterState,
                ZoneDistributionCenterZipCode = model.ZoneDistributionCenterZipCode,
                ZoneDistributionCenterCountryCode = model.ZoneDistributionCenterCountryCode,
                ZoneDistributionCenterCode = model.ZoneDistributionCenterCode,
                ActiveStatus = model.ActiveStatus,
                fkDistrictSalesZoneID = model.fkDistrictSalesZoneID
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }

}
