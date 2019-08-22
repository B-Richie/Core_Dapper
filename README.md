# Core_Dapper
Core 2.2 application using Dapper
		Simple web application using Dapper as an ORM


How to use:

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
