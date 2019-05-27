using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Services
{
    public interface IBaseService
    {
        T QueryFirstOrDefault<T>(string sql, object parameters = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null);
        int Execute(string sql, object parameters = null);
        IDbConnection Connect(string alias);
    }
}
