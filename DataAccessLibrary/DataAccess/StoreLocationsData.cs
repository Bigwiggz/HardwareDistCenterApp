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
    public class StoreLocationsData : IStoreLocationsData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<StoreLocations> _logger;
        private readonly ISqlQueries _sqlQuery;

        public StoreLocationsData(ISqlDataAccess sql, ILogger<StoreLocations> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["StoreLocationsDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from StoreLocations Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<StoreLocations>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["StoreLocationsGetAllAsync"];
            var result = await _sql.LoadData<StoreLocations, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<StoreLocations> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["StoreLocationsGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<StoreLocations, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(StoreLocations model)
        {
            string sqlString = _sqlQuery.sqlQueries["StoreLocationsInsertAsync"];

            var p = new
            {
                StorelocationsID = model.StorelocationsID,
                fkRegionalTerritoriesID = model.fkRegionalTerritoriesID,
                fkCompaniesID = model.fkCompaniesID,
                StoreName = model.StoreName,
                StoreLocation = model.StoreLocation,
                StoreStreet = model.StoreStreet,
                StoreCity = model.StoreCity,
                StoreState = model.StoreState,
                StoreZipCode = model.StoreZipCode,
                StoreCountryCode = model.StoreCountryCode,
                StoreEmail = model.StoreEmail,
                StorePhone = model.StorePhone,
                StoreCategory = model.StoreCategory,
                DateRegistered = model.DateRegistered,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(StoreLocations model)
        {
            string sqlString = _sqlQuery.sqlQueries["StoreLocationsUpdateByIdAsync"];
            var p = new
            {
                StorelocationsID = model.StorelocationsID,
                fkRegionalTerritoriesID = model.fkRegionalTerritoriesID,
                fkCompaniesID = model.fkCompaniesID,
                StoreName = model.StoreName,
                StoreLocation = model.StoreLocation,
                StoreStreet = model.StoreStreet,
                StoreCity = model.StoreCity,
                StoreState = model.StoreState,
                StoreZipCode = model.StoreZipCode,
                StoreCountryCode = model.StoreCountryCode,
                StoreEmail = model.StoreEmail,
                StorePhone = model.StorePhone,
                StoreCategory = model.StoreCategory,
                DateRegistered = model.DateRegistered,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
