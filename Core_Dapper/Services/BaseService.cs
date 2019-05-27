using Core_Dapper.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Services
{
    public class BaseService : IBaseService
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;
        private readonly IDbConnection _connection;
        private readonly string _connectionStringSection;

        public BaseService(IConfiguration config, IDbConnection connection, string connectionStringSection)
        {
            _config = config;
            _connection = connection;
            _connectionStringSection = connectionStringSection;
            _connectionString = _config.GetSection("ConnectionStrings").GetSection(_connectionStringSection).Value;
            connection.ConnectionString = _connectionString;
        }
        public IDbConnection Connect(string alias)
        {
            throw new NotImplementedException();
        }

        public int Execute(string sql, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using (_connection)
            {
                var result = await _connection.QueryAsync<T>(sql, parameters);

                return result;
            }
        }

        public T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
