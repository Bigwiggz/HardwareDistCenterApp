using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface ISalesData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<Sales>> GetAllAsync();
        Task<Sales> GetByIdAsync(object Id);
        Task<long> InsertAsync(Sales model);
        Task<long> UpdateByIdAsync(Sales model);
    }
}