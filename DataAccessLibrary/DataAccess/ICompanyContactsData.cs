using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface ICompanyContactsData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<CompanyContacts>> GetAllAsync();
        Task<CompanyContacts> GetByIdAsync(object Id);
        Task<long> InsertAsync(CompanyContacts model);
        Task<long> UpdateByIdAsync(CompanyContacts model);
    }
}