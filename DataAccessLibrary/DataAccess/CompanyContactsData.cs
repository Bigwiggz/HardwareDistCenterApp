using DataAccessLibrary.Internal;
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.SpecialModels;
using DataAccessLibrary.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public class CompanyContactsData : ICompanyContactsData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<CompanyContacts> _logger;
        private readonly ISqlQueries _sqlQuery;

        public CompanyContactsData(ISqlDataAccess sql, ILogger<CompanyContacts> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["CompanyContactsDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from CompanyContacts Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<CompanyContacts>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["CompanyContactsGetAllAsync"];
            var result = await _sql.LoadData<CompanyContacts, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<CompanyContacts> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["CompanyContactsGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<CompanyContacts, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(CompanyContacts model)
        {
            string sqlString = _sqlQuery.sqlQueries["CompanyContactsInsertAsync"];

            var p = new
            {
                CompanyContactsID = model.CompanyContactsID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ContactTitle = model.ContactTitle,
                ContactPhone = model.ContactPhone,
                ActiveStatus = model.ActiveStatus,
                fkStoreLocationsID = model.fkStoreLocationsID,
                ContactEmail = model.ContactEmail
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(CompanyContacts model)
        {
            string sqlString = _sqlQuery.sqlQueries["CompanyContactsUpdateByIdAsync"];
            var p = new
            {
                CompanyContactsID = model.CompanyContactsID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ContactTitle = model.ContactTitle,
                ContactPhone = model.ContactPhone,
                ActiveStatus = model.ActiveStatus,
                fkStoreLocationsID = model.fkStoreLocationsID,
                ContactEmail = model.ContactEmail
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        //Special Queries
        public async Task<IEnumerable<CompanyContactsWithStoreLocations>> GetCompanyContactsWithStoreLocationsAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["GetCompanyContactsWithStoreLocationsAsync"];
            var result = await _sql.LoadData<CompanyContactsWithStoreLocations, dynamic>(sqlString, new { });
            return result;
        }
    }
}
