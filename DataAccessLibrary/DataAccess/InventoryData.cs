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
    public class InventoryData : IInventoryData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<Inventory> _logger;
        private readonly ISqlQueries _sqlQuery;

        public InventoryData(ISqlDataAccess sql, ILogger<Inventory> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["InventorDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from InventoryData Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["InventoryGetAllAsync"];
            var result = await _sql.LoadData<Inventory, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<Inventory> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["InventoryGetByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.LoadSingleRecord<Inventory, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(Inventory model)
        {
            string sqlString = _sqlQuery.sqlQueries["InventoryInsertAsync"];

            var p = new
            {
                InventoryID = model.InventoryID,
                fkProductsCatalogID = model.fkProductsCatalogID,
                QuantityInStock = model.QuantityInStock,
                SalesTimeStamp = model.SalesTimeStamp,
                PurchaseOrSale = model.PurchaseOrSale,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(Inventory model)
        {
            string sqlString = _sqlQuery.sqlQueries["InventoryUpdateByIdAsync"];
            var p = new
            {
                InventoryID = model.InventoryID,
                fkProductsCatalogID = model.fkProductsCatalogID,
                QuantityInStock = model.QuantityInStock,
                SalesTimeStamp = model.SalesTimeStamp,
                PurchaseOrSale = model.PurchaseOrSale,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
