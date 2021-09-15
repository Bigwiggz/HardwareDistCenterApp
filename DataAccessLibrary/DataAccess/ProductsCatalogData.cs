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
    public class ProductsCatalogData : IProductsCatalogData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<ProductsCatalog> _logger;
        private readonly ISqlQueries _sqlQuery;

        public ProductsCatalogData(ISqlDataAccess sql, ILogger<ProductsCatalog> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["ProductsCatalogDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from ProductsCatalog Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<ProductsCatalog>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["ProductsCatalogGetAllAsync"];
            var result = await _sql.LoadData<ProductsCatalog, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<ProductsCatalog> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["ProductsCatalogGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<ProductsCatalog, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(ProductsCatalog model)
        {
            string sqlString = _sqlQuery.sqlQueries["ProductsCatalogInsertAsync"];

            var p = new
            {
                ProductCatalogID = model.ProductCatalogID,
                productCompanyPurchaseDescription = model.productCompanyPurchaseDescription,
                UniversalProductID = model.UniversalProductID,
                fkCompaniesID = model.fkCompaniesID,
                ActiveStatus = model.ActiveStatus,
                BaseRetailPrice = model.BaseRetailPrice,
                BaseWholeSalePrice = model.BaseWholeSalePrice,
                DateItemAddedUpdated = model.DateItemAddedUpdated
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(ProductsCatalog model)
        {
            string sqlString = _sqlQuery.sqlQueries["ProductsCatalogUpdateByIdAsync"];
            var p = new
            {
                ProductCatalogID = model.ProductCatalogID,
                productCompanyPurchaseDescription = model.productCompanyPurchaseDescription,
                UniversalProductID = model.UniversalProductID,
                fkCompaniesID = model.fkCompaniesID,
                ActiveStatus = model.ActiveStatus,
                BaseRetailPrice = model.BaseRetailPrice,
                BaseWholeSalePrice = model.BaseWholeSalePrice,
                DateItemAddedUpdated = model.DateItemAddedUpdated
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
