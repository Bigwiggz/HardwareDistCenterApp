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
    public class SalesData : ISalesData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<Sales> _logger;
        private readonly ISqlQueries _sqlQuery;

        public SalesData(ISqlDataAccess sql, ILogger<Sales> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["SalesDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from Sales Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<Sales>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["SalesGetAllAsync"];
            var result = await _sql.LoadData<Sales, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<Sales> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["SalesGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<Sales, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(Sales model)
        {
            string sqlString = _sqlQuery.sqlQueries["SalesInsertAsync"];

            var p = new
            {
                SalesID = model.SalesID,
                SalesInvoiceNumber = model.SalesInvoiceNumber,
                transactionCompanyPurchaseDescription = model.transactionCompanyPurchaseDescription,
                SalesNotesToClient = model.SalesNotesToClient,
                SalesDate = model.SalesDate,
                ActiveStatus = model.ActiveStatus,
                fkStoreLocationsID = model.fkStoreLocationsID,
                SaleAuthorizedBy = model.SaleAuthorizedBy
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(Sales model)
        {
            string sqlString = _sqlQuery.sqlQueries["SalesUpdateByIdAsync"];
            var p = new
            {
                SalesID = model.SalesID,
                SalesInvoiceNumber = model.SalesInvoiceNumber,
                transactionCompanyPurchaseDescription = model.transactionCompanyPurchaseDescription,
                SalesNotesToClient = model.SalesNotesToClient,
                SalesDate = model.SalesDate,
                ActiveStatus = model.ActiveStatus,
                fkStoreLocationsID = model.fkStoreLocationsID,
                SaleAuthorizedBy = model.SaleAuthorizedBy
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
