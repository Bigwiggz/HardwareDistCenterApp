using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface ICompaniesData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<Companies>> GetAllAsync();
        Task<Companies> GetByIdAsync(object Id);
        Task<object> InsertAsync(Companies model);
        Task<object> UpdateByIdAsync(Companies model);
    }
}