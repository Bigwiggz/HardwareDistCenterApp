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
    public class SalesDetailsData : ISalesDetailsData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<SalesDetails> _logger;
        private readonly ISqlQueries _sqlQuery;

        public SalesDetailsData(ISqlDataAccess sql, ILogger<SalesDetails> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["SalesDetailsDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from SalesDetails Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<SalesDetails>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["SalesDetailsGetAllAsync"];
            var result = await _sql.LoadData<SalesDetails, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<SalesDetails> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["SalesDetailsGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<SalesDetails, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(SalesDetails model)
        {
            string sqlString = _sqlQuery.sqlQueries["SalesDetailsInsertAsync"];

            var p = new
            {
                SalesDetailsID = model.SalesDetailsID,
                fkSalesID = model.fkSalesID,
                fkProductsCatalog = model.fkProductsCatalog,
                QuatitySold = model.QuatitySold,
                SalesSpecialNotes = model.SalesSpecialNotes,
                CompanyPurchaseDescription = model.CompanyPurchaseDescription,
                ActiveStatus = model.ActiveStatus,
                SalesDiscountAmount = model.SalesDiscountAmount,
                SalesLineItemCharge = model.SalesLineItemCharge
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(SalesDetails model)
        {
            string sqlString = _sqlQuery.sqlQueries["SalesDetailsUpdateByIdAsync"];
            var p = new
            {
                SalesDetailsID = model.SalesDetailsID,
                fkSalesID = model.fkSalesID,
                fkProductsCatalog = model.fkProductsCatalog,
                QuatitySold = model.QuatitySold,
                SalesSpecialNotes = model.SalesSpecialNotes,
                CompanyPurchaseDescription = model.CompanyPurchaseDescription,
                ActiveStatus = model.ActiveStatus,
                SalesDiscountAmount = model.SalesDiscountAmount,
                SalesLineItemCharge = model.SalesLineItemCharge
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
