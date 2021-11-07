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
    public class CPIIndexData : ICPIIndexData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<CPIIndex> _logger;
        private readonly ISqlQueries _sqlQuery;

        public CPIIndexData(ISqlDataAccess sql, ILogger<CPIIndex> logger, ISqlQueries sqlQuery)
        {
            _sql = sql;
            _logger = logger;
            _sqlQuery = sqlQuery;
        }

        public async Task<object> DeleteTrueByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["CPIIndexDeleteTrueByIdAsync"];
            var p = new
            {
                Id = Id
            };
            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            _logger.LogInformation("Record id {id} was deleted from CPIIndex Table at {DateTime.Now}");
            return result;
        }

        public async Task<IEnumerable<CPIIndex>> GetAllAsync()
        {
            string sqlString = _sqlQuery.sqlQueries["CPIIndexGetAllAsync"];
            var result = await _sql.LoadData<CPIIndex, dynamic>(sqlString, new { });
            return result;
        }

        public async Task<CPIIndex> GetByIdAsync(object Id)
        {
            string sqlString = _sqlQuery.sqlQueries["CPIIndexGetByIdAsync"];
            var p = new
            {
                CPIIndexID = Id
            };
            var result = await _sql.LoadSingleRecord<CPIIndex, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> InsertAsync(CPIIndex model)
        {
            string sqlString = _sqlQuery.sqlQueries["CPIIndexInsertAsync"];

            var p = new
            {
                CPIIndexID = model.CPIIndexID,
                ProductCPIDateEntry = model.ProductCPIDateEntry,
                CPIIndexValue = model.CPIIndexValue,
                ActiveStatus=model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }

        public async Task<long> UpdateByIdAsync(CPIIndex model)
        {
            string sqlString = _sqlQuery.sqlQueries["CPIIndexUpdateByIdAsync"];
            var p = new
            {
                CPIIndexID = model.CPIIndexID,
                ProductCPIDateEntry = model.ProductCPIDateEntry,
                CPIIndexValue = model.CPIIndexValue,
                ActiveStatus = model.ActiveStatus
            };

            var result = await _sql.SaveData<long, dynamic>(sqlString, p);
            return result;
        }
    }
}
