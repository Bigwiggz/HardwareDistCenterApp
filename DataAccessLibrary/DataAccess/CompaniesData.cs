using DataAccessLibrary.Internal;
using DataAccessLibrary.Models;
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
    public class CompaniesData : ICompaniesData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<Companies> _logger;
        private readonly ISqlQueries _sqlQuery;
        public CompaniesData(ISqlDataAccess sql, ILogger<Companies> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> InsertAsync(Companies model)
        {
            string sqlString = _sqlQuery.sqlQueries["CompaniesInsertAsync"];
            var p = new
            {
                CompaniesID = model.CompaniesID,
                CompanyName = model.CompanyName,
                CompanyNAICS = model.CompanyNAICS,
                CompanySIC = model.CompanySIC,
                CorporateEmail = model.CorporateEmail,
                CorporatePhone = model.CorporatePhone,
                CompanyCategory = model.CompanyCategory,
                EIN = model.EIN,
                ActiveStatus = model.ActiveStatus,
                IsSupplier = model.IsSupplier,
                IsClient = model.IsClient,
                DateCompanyAddedUpdated = model.DateCompanyAddedUpdated
            };

            long result = await _sql.SaveData<long, dynamic>(sqlString, p);

            return result;
        }

        public async Task<IEnumerable<Companies>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["CompaniesGetAllAsync"];
            var result = await _sql.LoadData<Companies, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<Companies> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["CompaniesGetByIdAsync"];
            var p = new
            {
                Id = Id
            };

            var result = await _sql.LoadSingleRecord<Companies, dynamic>(sqlString, p);
            return result;
        }

        public async Task<object> UpdateByIdAsync(Companies model)
        {
            string sqlString = _sqlQuery.sqlQueries["CompaniesUpdateByIdAsync"];

            var p = new
            {
                CompaniesID = model.CompaniesID,
                CompanyName = model.CompanyName,
                CompanyNAICS = model.CompanyNAICS,
                CompanySIC = model.CompanySIC,
                CorporateEmail = model.CorporateEmail,
                CorporatePhone = model.CorporatePhone,
                CompanyCategory = model.CompanyCategory,
                EIN = model.EIN,
                ActiveStatus = model.ActiveStatus,
                IsSupplier = model.IsSupplier,
                IsClient = model.IsClient,
                DateCompanyAddedUpdated = model.DateCompanyAddedUpdated
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["CompaniesDeleteTrueByIdAsync"];

            var p = new
            {
                Id = Id
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id{id} was deleted from Companies table on {DateTime.Now}");
            return result;
        }
    }
}
