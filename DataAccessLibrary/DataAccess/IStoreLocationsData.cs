using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface IStoreLocationsData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<StoreLocations>> GetAllAsync();
        Task<StoreLocations> GetByIdAsync(object Id);
        Task<long> InsertAsync(StoreLocations model);
        Task<long> UpdateByIdAsync(StoreLocations model);
    }
}