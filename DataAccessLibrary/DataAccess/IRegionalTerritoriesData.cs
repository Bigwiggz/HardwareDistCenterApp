using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface IRegionalTerritoriesData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<RegionalTerritories>> GetAllAsync();
        Task<RegionalTerritories> GetByIdAsync(object Id);
        Task<long> InsertAsync(RegionalTerritories model);
        Task<long> UpdateByIdAsync(RegionalTerritories model);
    }
}