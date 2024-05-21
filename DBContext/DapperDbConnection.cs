using System.Data;
using Microsoft.Data.SqlClient;

namespace AppointAPI.DBContext
{
    public class DapperDbConnection: IDapperDbConnection
    {
        public readonly string _connectionString;

        public DapperDbConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
