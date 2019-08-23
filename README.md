# ASP Core 2.2 Web Application Using Dapper

Simple IOC web application using Dapper as an ORM


# How to use:

appsettings.json

Add your providers and connection strings as follows:

			"DatabaseConnections": {
			    "OracleConnections": [
			      {
				"Alias": "Optional",        
				"ConnectionString": "Required"
			      },
			      {
				"Alias": "Optional",        
				"ConnectionString": "Required"
			      }
			    ],
			    "MSSqlConnections": [
			      {
				"Alias": "Optional",        
				"ConnectionString": "Required"
			      }
			    ]
			  }
Reference the Dapper_DAL data access layer project in your client

Inherit the BaseService class in your service layer:

		public class ArtistService : BaseService, IArtistService
		{
		}

Override the two abstract properties from the DAL project:

		protected override IDbConnection Connection { get; set; }
        	protected override string SQL { get; set; }
		
IDbConnection is the connection object passed into the DAL

SQL is the string object passed into the DAL if you want to use/set up generic CRUD methods such as:

		protected override Artist Get<Artist>(int id)
		{
		    SQL = "Select * from dbo.Artist a where a.ArtistID = :id";

		    var result = base.Get<Artist>(id);
		    return result;
		}
		
Next, build the constructor:

		public ArtistService(IMapper mapper, DatabaseConnections databaseConnections, IOracleParameterFactory parameterFactory)
		{
		    _mapper = mapper;
		    _DatabaseConnections = databaseConnections;
		    _parameterFactory = parameterFactory;
		    Connection = _DatabaseConnections.MSSqlConnections.Where(alias => alias.Alias == "Music").FirstOrDefault().dbConnection;
		}
		
IMapper-Automapper object for mapping db entity to DTO

DatabaseConnections-DAL class object that stores all of the db connections from the appsettings.json file

IOracleParameterFactory-factory class for creating parameters for Oracle databases (if needed)

The connection is being set in the constructor for this example. If you're planning to use more than one connection, set the Connection object inside the calling method. If you're planning to use more than one provider, bypass using the Connection object and the DAL all togther and simple call the Dapper methods directly in your service class.


Here are some sample methods calling the Dapper DAL:

		public async Task<IEnumerable<IArtistDto>> GetListAsync()
		{
		    const string sql = "Select * from dbo.Artist";
		    var result = await QueryAsync<Artist>(sql);
		    var mappedResult = _mapper.Map<IEnumerable<IArtistDto>>(result);
		    return mappedResult;
		}
		
		public async Task<IArtistDto> GetFirstOrDefaultAsync(int id)
		{
		    const string sql = "Select * from dbo.Artist a where a.ArtistID = @id";
		    var result = await QueryFirstOrDefaultAsync<Artist>(sql, new { id });
		    var model = _mapper.Map<IArtistDto>(result);
		    return model;
		}

		public async Task<int> DeleteAsync(decimal id)
		{
		    const string sql = "Delete from dbo.Artist a where a.ArtistID = @id";
		    var result = await ExecuteAsync(sql, new { id });
		    return result;
		}
		
		public IArtistDto CallProcedure(string Id)
		{
		    const string sql = "GET_ARTIST";
		    var param2 = _parameterFactory.CreateOracleParameters();
		    param2.Add("artistId", OracleDbType.Int32, ParameterDirection.Input, Id);
		    param2.Add("artist", OracleDbType.RefCursor, ParameterDirection.Output);
		    var result = QueryFirstOrDefault<Artist>(sql, param2, null, null, CommandType.StoredProcedure);
		    var mappedResult = _mapper.Map<IArtistDto>(result);
		    return mappedResult;
		}
