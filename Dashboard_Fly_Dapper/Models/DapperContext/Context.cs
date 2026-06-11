using Microsoft.Data.SqlClient;
using System.Data;

namespace Dashboard_Fly_Dapper.Models.DapperContext
{
    public class Context
        {
            private readonly IConfiguration _configuration;
            private readonly string _connectionstring;

            public Context(IConfiguration configuration)
            {
                _configuration = configuration;
                _connectionstring = _configuration.GetConnectionString("connection");
            }

            public IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
