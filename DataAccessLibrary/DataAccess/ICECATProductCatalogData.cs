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
    public class ICECATProductCatalogData : IICECATProductCatalogData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<ICECATProductCatalog> _logger;
        private readonly ISqlQueries _sqlQuery;

        public ICECATProductCatalogData(ISqlDataAccess sql, ILogger<ICECATProductCatalog> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["ICECATProductCatalogDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from ICECATProductCatalog Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<ICECATProductCatalog>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["ICECATProductCatalogGetAllAsync"];
            var result = await _sql.LoadData<ICECATProductCatalog, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<ICECATProductCatalog> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["ICECATProductCatalogGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<ICECATProductCatalog, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(ICECATProductCatalog model)
        {
            string sqlString = _sqlQuery.sqlQueries["ICECATProductCatalogInsertAsync"];

            var p = new
            {
                ICECATEProductCatalogID = model.ICECATEProductCatalogID,
                ManufacturerProductID = model.ManufacturerProductID,
                EAN_UPC = model.EAN_UPC,
                HtmlPath = model.HtmlPath,
                Limited = model.Limited,
                DistributorInfoUpdated = model.DistributorInfoUpdated,
                HighPic = model.HighPic,
                HighPicSize = model.HighPicSize,
                HighPicWidth = model.HighPicWidth,
                HighPicHeight = model.HighPicHeight,
                ProductID = model.ProductID,
                Updated = model.Updated,
                Quality = model.Quality,
                ProdID = model.ProdID,
                fkSupplierID = model.fkSupplierID,
                Catid = model.Catid,
                On_Market = model.On_Market,
                ModelName = model.ModelName,
                ProductView = model.ProductView,
                InitialUnitPrice = model.InitialUnitPrice,
                DateAdded = model.DateAdded,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(ICECATProductCatalog model)
        {
            string sqlString = _sqlQuery.sqlQueries["ICECATProductCatalogUpdateByIdAsync"];
            var p = new
            {
                ICECATEProductCatalogID = model.ICECATEProductCatalogID,
                ManufacturerProductID = model.ManufacturerProductID,
                EAN_UPC = model.EAN_UPC,
                HtmlPath = model.HtmlPath,
                Limited = model.Limited,
                DistributorInfoUpdated = model.DistributorInfoUpdated,
                HighPic = model.HighPic,
                HighPicSize = model.HighPicSize,
                HighPicWidth = model.HighPicWidth,
                HighPicHeight = model.HighPicHeight,
                ProductID = model.ProductID,
                Updated = model.Updated,
                Quality = model.Quality,
                ProdID = model.ProdID,
                fkSupplierID = model.fkSupplierID,
                Catid = model.Catid,
                On_Market = model.On_Market,
                ModelName = model.ModelName,
                ProductView = model.ProductView,
                InitialUnitPrice = model.InitialUnitPrice,
                DateAdded = model.DateAdded,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
