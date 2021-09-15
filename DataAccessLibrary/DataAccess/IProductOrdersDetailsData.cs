using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface IProductOrdersDetailsData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<ProductOrdersDetails>> GetAllAsync();
        Task<ProductOrdersDetails> GetByIdAsync(object Id);
        Task<long> InsertAsync(ProductOrdersDetails model);
        Task<long> UpdateByIdAsync(ProductOrdersDetails model);
    }
}