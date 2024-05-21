using AppointAPI.DBContext;
using AppointAPI.Models;
using Dapper;
using System.Data;

namespace AppointAPI.Repositories
{
    public class AppointmentRepository:IAppointmentRepository
    {
        public IDapperDbConnection _dapperDbConnection;
        public AppointmentRepository(IDapperDbConnection dapperDbConnection)
        {
            _dapperDbConnection = dapperDbConnection;
        }
        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            string query = "[dbo].[GetAllAppointments]";
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryAsync<Appointment,Customer,Appointment>(query, (app, cust) =>
                {
                    app.Customer = cust;
                    return app;
                }, null, null, true, splitOn: "Customer", null,
                        commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Appointment> GetAppointmentByCodeAsync(string code)
        {
            string query = "[dbo].[GetAppointmentByCode]";
            var parameters = new DynamicParameters();
            parameters.Add(name: "@Code", value: code,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return (await db.QueryAsync<Appointment, Customer, Appointment>(query, (app, cust) =>
                    {
                        app.Customer = cust;
                        return app;
                    },
                    parameters, null, true, splitOn: "Customer", null,
                    commandType: CommandType.StoredProcedure
                )).FirstOrDefault();
            }
        }

        public async Task<bool> CreateAppointmentAsync(AppointmentDTO Appointment)
        {
            string query = "[dbo].[CreateAppointment]";

            var parameters = new DynamicParameters();
            parameters.Add(name: "@Code", value: Appointment.Code,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Date", value: Appointment.Date,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Customer", value: Appointment.Customer,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Title", value: Appointment.Title,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Description", value: Appointment.Description,
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

        public async Task<bool> UpdateAppointmentAsync(AppointmentDTO Appointment)
        {
            string query = "[dbo].[UpdateAppointment]";

            var parameters = new DynamicParameters();
            parameters.Add(name: "@Code", value: Appointment.Code,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Date", value: Appointment.Date,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Customer", value: Appointment.Customer,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Title", value: Appointment.Title,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add(name: "@Description", value: Appointment.Description,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                int rowsAffected = await db.ExecuteAsync(query, parameters, 
                    commandType:CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAppointmentAsync(string code)
        {
            string query = "[dbo].[DeleteAppointment]";

            var parameters = new DynamicParameters();
            parameters.Add(name: "@Code", value: code,
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
