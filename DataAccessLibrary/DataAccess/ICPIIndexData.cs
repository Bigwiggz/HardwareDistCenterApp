using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface ICPIIndexData
    {
        Task<object> DeleteTrueByIdAsync(object Id);
        Task<IEnumerable<CPIIndex>> GetAllAsync();
        Task<CPIIndex> GetByIdAsync(object Id);
        Task<long> InsertAsync(CPIIndex model);
        Task<long> UpdateByIdAsync(CPIIndex model);
    }
}