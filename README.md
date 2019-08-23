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
