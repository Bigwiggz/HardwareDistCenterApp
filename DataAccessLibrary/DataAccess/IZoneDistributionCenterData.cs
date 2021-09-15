using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface IZoneDistributionCenterData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<ZoneDistributionCenters>> GetAllAsync();
        Task<ZoneDistributionCenters> GetByIdAsync(object Id);
        Task<long> InsertAsync(ZoneDistributionCenters model);
        Task<long> UpdateByIdAsync(ZoneDistributionCenters model);
    }
}