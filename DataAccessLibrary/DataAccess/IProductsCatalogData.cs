using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface IProductsCatalogData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<ProductsCatalog>> GetAllAsync();
        Task<ProductsCatalog> GetByIdAsync(object Id);
        Task<long> InsertAsync(ProductsCatalog model);
        Task<long> UpdateByIdAsync(ProductsCatalog model);
    }
}