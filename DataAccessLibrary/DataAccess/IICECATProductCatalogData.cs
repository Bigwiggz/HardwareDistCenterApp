using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface IICECATProductCatalogData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<ICECATProductCatalog>> GetAllAsync();
        Task<ICECATProductCatalog> GetByIdAsync(object Id);
        Task<long> InsertAsync(ICECATProductCatalog model);
        Task<long> UpdateByIdAsync(ICECATProductCatalog model);
    }
}