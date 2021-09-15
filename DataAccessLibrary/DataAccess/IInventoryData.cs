using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface IInventoryData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<Inventory> GetByIdAsync(object Id);
        Task<long> InsertAsync(Inventory model);
        Task<long> UpdateByIdAsync(Inventory model);
    }
}