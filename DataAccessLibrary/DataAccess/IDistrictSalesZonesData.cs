using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface IDistrictSalesZonesData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<DistrictSalesZones>> GetAllAsync();
        Task<DistrictSalesZones> GetByIdAsync(object Id);
        Task<long> InsertAsync(DistrictSalesZones model);
        Task<long> UpdateByIdAsync(DistrictSalesZones model);
    }
}