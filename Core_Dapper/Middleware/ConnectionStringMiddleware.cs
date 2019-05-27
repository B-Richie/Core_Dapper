using Dapper_DAL.BaseService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Middleware
{
    public class ConnectionStringMiddleware
    {
        private readonly RequestDelegate Next;
        //private readonly IOptions<ConnectionStrings> ConnectionString;
        //private readonly IApplicationBuilder ApplicationBuilder;
        //private readonly IServiceCollection ServiceCollection;
        //private readonly xIDataBaseConnections DatabaseConnections;
        //private readonly xIConnectionFactory ConnectionFactory;
        //private IDbDictionary<string, IDbConnection> DbDictionary;
        //private readonly HttpContext Context;
        //private readonly IConnectionFactory ConnectionFactory;
        private readonly DatabaseConnections DatabaseConnections;

        //public ConnectionStringMiddleware(RequestDelegate next, IOptions<ConnectionStrings> connectionString)
        //{
        //    Next = next;            
        //    ConnectionString = connectionString;
        //    //Context = context;
        //    //ApplicationBuilder = applicationBuilder;
        //    //ServiceCollection = collection;
        //    //AddDbConnection(connectionString);

        //    //ConnectionStrings = optionsAccessor.Value;
        //}

        public ConnectionStringMiddleware(RequestDelegate next, DatabaseConnections dataBaseConnections)
        {
            Next = next;
            //ConnectionFactory = connectionFactory;
            DatabaseConnections = dataBaseConnections;            
            //ConnectionString = connectionString;
            //Context = context;
            //ApplicationBuilder = applicationBuilder;
            //ServiceCollection = collection;
            //AddDbConnection(connectionString);

            //ConnectionStrings = optionsAccessor.Value;
        }

        //public ConnectionStringMiddleware(RequestDelegate next, IOptions<ConnectionStringContents> optionsAccessor)
        //{
        //    Next = next;
        //    ConnectionStrings = optionsAccessor.Value;
        //}

        //private void AddDbConnection(IOptions<ConnectionStrings> options)
        //{
            
        //    switch (options.Value.ProviderName)
        //    {
        //        case string Oracle when options.Value.ProviderName.Contains("Oracle", StringComparison.CurrentCultureIgnoreCase):                    
        //        default:
        //            //var serviceProviders = ApplicationBuilder.ApplicationServices;
        //            //var ora = (OracleConnection)serviceProviders.GetService(typeof(OracleConnection));
        //            //options.Value.Connection = ora;
        //            //Type oracleType = typeof(OracleConnection);
        //            //options.Value.Connection = ApplicationBuilder.ApplicationServices.GetService(oracleType);
        //            //options.Value.Connection = new OracleConnection(options.Value.ConnectionString);
                    
        //            break;
        //        case string MSSql when options.Value.ProviderName.Contains("MSSql", StringComparison.CurrentCultureIgnoreCase):                    
        //            break;
        //        case string Mongo when options.Value.ProviderName.Contains("Mongo", StringComparison.CurrentCultureIgnoreCase):
        //            break;
        //        case string MySql when options.Value.ProviderName.Contains("MySql", StringComparison.CurrentCultureIgnoreCase):
        //            break;
        //        case string NoSql when options.Value.ProviderName.Contains("NoSql", StringComparison.CurrentCultureIgnoreCase):
        //            break;
        //        case string Db2 when options.Value.ProviderName.Contains("Db2", StringComparison.CurrentCultureIgnoreCase):
        //            break;
        //        case string Hadoop when options.Value.ProviderName.Contains("Hadoop", StringComparison.CurrentCultureIgnoreCase):
        //            break;
        //    }
        //}

        public async Task Invoke(HttpContext context)
        {
            //var connections = context.RequestServices.GetService<_IDbConnection>();
           // var connectionList = context.RequestServices.GetService<IEnumerable<IDbDictionary<string, IDbConnection>>>().ToList();
            
            var connectionTypes = context.RequestServices.GetServices<IDbConnection>();

            //DatabaseConnections.ConnectionStrings.ToList().ForEach(conn =>
            //{
            //    //var connectionFactory = context.RequestServices.GetService<IConnectionFactory>();
            //    //var connections = context.RequestServices.GetService<IDbDictionary<string, IDbConnection>>();
                
                
            //    switch (conn.ProviderName)
            //    {
            //        case string Oracle when conn.ProviderName.Contains("Oracle", StringComparison.CurrentCultureIgnoreCase):                        
            //        default:                        
            //            var ora = connectionTypes.Where(w => w.GetType() == typeof(OracleConnection)).FirstOrDefault();
            //            var oraDict = context.RequestServices.GetService<IDbDictionary<string, IDbConnection>>();
            //            oraDict.Add(conn.Alias, ora);
            //            connectionList.Add(oraDict);
            //            //var db = context.RequestServices.GetService<xIDbConn>();
            //            //var ora = context.RequestServices.GetService<BaseOracleConnection>();
            //            //ora.ConnectionString = conn.ConnectionString;
            //            //db.Alias = conn.Alias;
            //            //db.DbConnection = ora;
            //            //connectionFactory.DatabaseConnections.Add(db);
            //            //var db = ora.GetConnection();
            //            //connections.Add(conn.Alias, ora.Connection);
                        
            //            break;
            //        case string MSSql when conn.ProviderName.Contains("MSSql", StringComparison.CurrentCultureIgnoreCase):
            //            var sql = connectionTypes.Where(w => w.GetType() == typeof(SqlConnection)).FirstOrDefault();
            //            var sqlDict = context.RequestServices.GetService<IDbDictionary<string, IDbConnection>>();
            //            sqlDict.Add(conn.Alias, sql);
            //            connectionList.Add(sqlDict);
            //            break;
            //        case string Mongo when conn.ProviderName.Contains("Mongo", StringComparison.CurrentCultureIgnoreCase):
            //            break;
            //        case string MySql when conn.ProviderName.Contains("MySql", StringComparison.CurrentCultureIgnoreCase):
            //            break;
            //        case string NoSql when conn.ProviderName.Contains("NoSql", StringComparison.CurrentCultureIgnoreCase):
            //            break;
            //        case string Db2 when conn.ProviderName.Contains("Db2", StringComparison.CurrentCultureIgnoreCase):
            //            break;
            //        case string Hadoop when conn.ProviderName.Contains("Hadoop", StringComparison.CurrentCultureIgnoreCase):
            //            break;
            //    }
            //    //connectionFactory.DbConnections = connections;
            //});

            //connections.DbConnections = connectionList;
            //var connStrings = context.RequestServices.GetService<IConnectionFactory>();
            //var dict = context.RequestServices.GetService<IDbDictionary<string, IDbConnection>>();
            //Guid g = new Guid();           
            //dict.Add("WebRlc", new OracleConnection(DatabaseConnections.ConnectionStrings[0].ConnectionString));
            //connStrings.guid = Guid.NewGuid();
            //connStrings.DbConnections = dict;
            //ConnectionFactory.DbConnection = new OracleConnection();
            //ConnectionFactory.DbConnection.ConnectionString = dataBaseConnections.ConnectionStrings.FirstOrDefault().ConnectionString;
            //var conn = context.RequestServices.GetService<IConnectionFactory>();
            //conn.DbConnection.ConnectionString = DatabaseConnections.ConnectionStrings.FirstOrDefault().ConnectionString;

            //DatabaseConnections.ConnectionStrings.ToList().ForEach(c =>
            //{
            //    var conn = (OracleConnection)context.RequestServices.GetService<IDbConnection>();
            //    conn.ConnectionString = c.ConnectionString;
            //});
            //var db = context.RequestServices.GetService<IDataBaseConnections>();
            //ConnectionString.Value.Connection = new OracleConnection(ConnectionString.Value.ConnectionString);
            //ConnectionString.Value.Connection = context.RequestServices.GetService<OracleConnection>();
            //await context.Response.WriteAsync("testing..testing..");
            //var t = ConnectionStrings.Connection.GetType();
            //var x = context.RequestServices.GetService(t);
            await Next.Invoke(context);
            //await Next(context);
        }
    }

    public static class ConnectionStringMiddlewareExtensions
    {
        public static IApplicationBuilder UseConnectionStringMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConnectionStringMiddleware>();
        }
    }

    public static class ConnectionStringMiddlewareWithParamsExtensions
    {
        //public static IApplicationBuilder UseConnectionStringMiddlewareParams(this IApplicationBuilder builder)
        //{
        //    return builder.UseMiddleware<ConnectionStringMiddleware>();
        //}

        //public static IApplicationBuilder UseConnectionStringParamsMiddleware(this IApplicationBuilder builder, ConnectionStrings connectionStrings)
        //{
        //    return builder.UseMiddleware<ConnectionStringMiddleware>(new OptionsWrapper<ConnectionStrings>(connectionStrings));
        //}

        public static IApplicationBuilder UseConnectionStringParamsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConnectionStringMiddleware>();
        }
    }
}
