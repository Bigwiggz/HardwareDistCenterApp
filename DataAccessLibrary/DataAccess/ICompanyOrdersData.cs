using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface ICompanyOrdersData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<CompanyOrders>> GetAllAsync();
        Task<CompanyOrders> GetByIdAsync(object Id);
        Task<long> InsertAsync(CompanyOrders model);
        Task<long> UpdateByIdAsync(CompanyOrders model);
    }
}