using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Internal
{
    public interface ISqlDataAccess
    {
        void CommitTransaction();
        void Dispose();
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters);
        Task<List<T>> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);
        Task<T> LoadSingleObjectInTransaction<T, U>(string storedProcedure, U parameters);
        Task<T> LoadSingleRecord<T, U>(string storedProcedure, U parameters);
        void RollBackTransaction();
        Task<int> SaveData<T,U>(string storedProcedure, U parameters);
        void SaveDataInTransaction<T>(string storedProcedure, T parameters);
        void StartTransaction(string connectionStringName);
    }
}