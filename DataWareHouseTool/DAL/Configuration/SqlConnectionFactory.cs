using System.Data;
using System.Data.SqlClient;
using DataWareHouseTool.DAL.Configuration.Interfaces;
using DataWareHouseTool.Services.Interfaces;

namespace DataWareHouseTool.DAL.Configuration
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly IApplicationContextService _applicationContextService;
        private readonly ILoggingService _loggingService;

        public SqlConnectionFactory(IApplicationContextService applicationContextService, ILoggingService loggingService)
        {
            _applicationContextService = applicationContextService;
            _loggingService = loggingService;
        }

        private static IDbConnection GetConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                return null;
            }

            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public IDbConnection GetInputInstance() => GetConnection(_applicationContextService?.InputConnectionString);

        public IDbConnection GetOutputInstance() => GetConnection(_applicationContextService?.OutputConnectionString);

        public bool IsConnectionAvailable(string connectionString)
        {
            try
            {
                using (var connection = GetConnection(connectionString))
                {
                    if (connection == null)
                    {
                        return false;
                    }
                    connection.Close();
                    return true;
                }
            }
            catch (SqlException exception)
            {
                _loggingService?.Log(exception);
                return false;
            }
        }
    }
}
