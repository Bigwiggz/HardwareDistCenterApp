using System.Collections.Generic;

namespace DataAccessLibrary.Services
{
    public interface ISqlQueries
    {
        Dictionary<string, string> sqlQueries { get; }
    }
}