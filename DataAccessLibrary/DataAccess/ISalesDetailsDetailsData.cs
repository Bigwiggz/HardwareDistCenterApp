using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface ISalesDetailsData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<SalesDetails>> GetAllAsync();
        Task<SalesDetails> GetByIdAsync(object Id);
        Task<long> InsertAsync(SalesDetails model);
        Task<long> UpdateByIdAsync(SalesDetails model);
    }
}