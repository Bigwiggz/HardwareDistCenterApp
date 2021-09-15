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
    public class ProductOrdersDetailsData : IProductOrdersDetailsData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<ProductOrdersDetails> _logger;
        private readonly ISqlQueries _sqlQuery;

        public ProductOrdersDetailsData(ISqlDataAccess sql, ILogger<ProductOrdersDetails> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["ProductOrdersDetailsDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from ProductOrderDetails Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<ProductOrdersDetails>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["ProductOrdersDetailsGetAllAsync"];
            var result = await _sql.LoadData<ProductOrdersDetails, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<ProductOrdersDetails> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["ProductOrdersDetailsGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<ProductOrdersDetails, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(ProductOrdersDetails model)
        {
            string sqlString = _sqlQuery.sqlQueries["ProductOrdersDetailsInsertAsync"];

            var p = new
            {
                ProductOrdersID = model.ProductOrdersID,
                fkProductCatalogID = model.fkProductCatalogID,
                QuatityofProductOrdered = model.QuatityofProductOrdered,
                fkCompanyOrdersID = model.fkCompanyOrdersID,
                LineItemCompanyOrderCosts = model.LineItemCompanyOrderCosts,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(ProductOrdersDetails model)
        {
            string sqlString = _sqlQuery.sqlQueries["ProductOrdersDetailsUpdateByIdAsync"];
            var p = new
            {
                ProductOrdersID = model.ProductOrdersID,
                fkProductCatalogID = model.fkProductCatalogID,
                QuatityofProductOrdered = model.QuatityofProductOrdered,
                fkCompanyOrdersID = model.fkCompanyOrdersID,
                LineItemCompanyOrderCosts = model.LineItemCompanyOrderCosts,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
