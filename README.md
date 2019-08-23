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
