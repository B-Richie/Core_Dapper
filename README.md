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

Inherit the BaseService class in your service layer:

		public class MyServiceLayer : BaseService
		{
		
		}
