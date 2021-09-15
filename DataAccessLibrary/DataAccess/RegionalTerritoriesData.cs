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
    public class RegionalTerritoriesData : IRegionalTerritoriesData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<RegionalTerritories> _logger;
        private readonly ISqlQueries _sqlQuery;

        public RegionalTerritoriesData(ISqlDataAccess sql, ILogger<RegionalTerritories> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["RegionalTerritoriesDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from Regional Territories Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<RegionalTerritories>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["RegionalTerritoriesGetAllAsync"];
            var result = await _sql.LoadData<RegionalTerritories, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<RegionalTerritories> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["RegionalTerritoriesGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<RegionalTerritories, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(RegionalTerritories model)
        {
            string sqlString = _sqlQuery.sqlQueries["RegionalTerritoriesInsertAsync"];

            var p = new
            {
                RegionalTerritoriesID = model.RegionalTerritoriesID,
                TerritoryColorCode = model.TerritoryColorCode,
                TerritoryGeometry = model.TerritoryGeometry,
                TerritoryNumber = model.TerritoryNumber,
                TerritoryPerimeterLength = model.TerritoryPerimeterLength,
                TerritoryArea = model.TerritoryArea,
                TerritoryAccount = model.TerritoryAccount,
                territoryCompanyPurchaseDescription = model.territoryCompanyPurchaseDescription,
                ActiveStatus = model.ActiveStatus,
                DateTerritoryAddedUpdated = model.DateTerritoryAddedUpdated,
                fkDistrictSalesZoneID = model.fkDistrictSalesZoneID,
                RegionalSupervisorID = model.RegionalSupervisorID
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(RegionalTerritories model)
        {
            string sqlString = _sqlQuery.sqlQueries["RegionalTerritoriesUpdateByIdAsync"];
            var p = new
            {
                RegionalTerritoriesID = model.RegionalTerritoriesID,
                TerritoryColorCode = model.TerritoryColorCode,
                TerritoryGeometry = model.TerritoryGeometry,
                TerritoryNumber = model.TerritoryNumber,
                TerritoryPerimeterLength = model.TerritoryPerimeterLength,
                TerritoryArea = model.TerritoryArea,
                TerritoryAccount = model.TerritoryAccount,
                territoryCompanyPurchaseDescription = model.territoryCompanyPurchaseDescription,
                ActiveStatus = model.ActiveStatus,
                DateTerritoryAddedUpdated = model.DateTerritoryAddedUpdated,
                fkDistrictSalesZoneID = model.fkDistrictSalesZoneID,
                RegionalSupervisorID = model.RegionalSupervisorID
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
