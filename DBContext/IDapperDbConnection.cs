using System.Data;

namespace AppointAPI.DBContext
{
    public interface IDapperDbConnection
    {
        public IDbConnection CreateConnection();
    }
}
