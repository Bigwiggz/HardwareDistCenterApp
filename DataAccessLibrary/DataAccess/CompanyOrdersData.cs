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
    public class CompanyOrdersData : ICompanyOrdersData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<CompanyOrders> _logger;
        private readonly ISqlQueries _sqlQuery;

        public CompanyOrdersData(ISqlDataAccess sql, ILogger<CompanyOrders> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["CompanyOrdersDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from CompanyOrderDetails Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<CompanyOrders>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["CompanyOrdersGetAllAsync"];
            var result = await _sql.LoadData<CompanyOrders, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<CompanyOrders> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["CompanyOrdersGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<CompanyOrders, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(CompanyOrders model)
        {
            string sqlString = _sqlQuery.sqlQueries["CompanyOrdersInsertAsync"];

            var p = new
            {
                CompanyOrdersID = model.CompanyOrdersID,
                CompanyPurchaseDescription = model.CompanyPurchaseDescription,
                CompanyOrderCosts = model.CompanyOrderCosts,
                ActiveStatus = model.ActiveStatus,
                DateTimeOrdered = model.DateTimeOrdered,
                fkProductOrderingDetailsID = model.fkProductOrderingDetailsID,
                fkStoreLocationsID = model.fkStoreLocationsID,
                OrderAuthorizedBy = model.OrderAuthorizedBy
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(CompanyOrders model)
        {
            string sqlString = _sqlQuery.sqlQueries["CompanyOrdersUpdateByIdAsync"];
            var p = new
            {
                CompanyOrdersID = model.CompanyOrdersID,
                CompanyPurchaseDescription = model.CompanyPurchaseDescription,
                CompanyOrderCosts = model.CompanyOrderCosts,
                ActiveStatus = model.ActiveStatus,
                DateTimeOrdered = model.DateTimeOrdered,
                fkProductOrderingDetailsID = model.fkProductOrderingDetailsID,
                fkStoreLocationsID = model.fkStoreLocationsID,
                OrderAuthorizedBy = model.OrderAuthorizedBy
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
