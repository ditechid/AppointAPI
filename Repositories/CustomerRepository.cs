using AppointAPI.DBContext;
using AppointAPI.Models;
using Dapper;
using System.Data;

namespace AppointAPI.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        public IDapperDbConnection _dapperDbConnection;
        public CustomerRepository(IDapperDbConnection dapperDbConnection)
        {
            _dapperDbConnection = dapperDbConnection;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            string query = "[dbo].[GetAllCustomers]";
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryAsync<Customer>(query,null, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            string query = "[dbo].[GetCustomerById]";
            var parameters = new DynamicParameters();
            parameters.Add(name: "@CustID", value: id,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryFirstOrDefaultAsync<Customer>(query, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> CreateCustomerAsync(Customer Customer)
        {
            string query = "[dbo].[CreateCustomer]";

            var parameters = new DynamicParameters();
            parameters.Add(name: "@CustID", value: Customer.Id,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@FirstName", value: Customer.FirstName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@LastName", value: Customer.LastName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@FullName", value: Customer.FullName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Gender", value: Customer.Gender,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Address", value: Customer.Address,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@City", value: Customer.City,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Region", value: Customer.Region,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Country", value: Customer.Country,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Phone", value: Customer.Phone,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Email", value: Customer.Email,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@PostalCode", value: Customer.PostalCode,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Note", value: Customer.Note,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                try
                {
                    await db.ExecuteAsync(query, parameters,
                        commandType: CommandType.StoredProcedure);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> UpdateCustomerAsync(Customer Customer)
        {
            string query = "[dbo].[UpdateCustomer]";

            var parameters = new DynamicParameters();
            parameters.Add(name: "@CustID", value: Customer.Id,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@FirstName", value: Customer.FirstName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@LastName", value: Customer.LastName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@FullName", value: Customer.FullName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Gender", value: Customer.Gender,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Address", value: Customer.Address,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@City", value: Customer.City,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Region", value: Customer.Region,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Country", value: Customer.Country,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Phone", value: Customer.Phone,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Email", value: Customer.Email,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@PostalCode", value: Customer.PostalCode,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Note", value: Customer.Note,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                int rowsAffected = await db.ExecuteAsync(query, parameters, 
                    commandType:CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteCustomerAsync(string id)
        {
            string query = "[dbo].[DeleteCustomer]";

            var parameters = new DynamicParameters();
            parameters.Add(name: "@CustID", value: id,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                int rowsAffected = await db.ExecuteAsync(query, parameters,
                     commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }
    }
}
