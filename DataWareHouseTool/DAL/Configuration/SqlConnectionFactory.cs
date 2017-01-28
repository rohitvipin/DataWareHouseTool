using System.Data;
using System.Data.SqlClient;
using DataWareHouseTool.DAL.Configuration.Interfaces;
using DataWareHouseTool.Services.Interfaces;

namespace DataWareHouseTool.DAL.Configuration
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly IApplicationContextService _applicationContextService;

        public SqlConnectionFactory(IApplicationContextService applicationContextService)
        {
            _applicationContextService = applicationContextService;
        }

        public IDbConnection GetInputInstance()
        {
            if (string.IsNullOrEmpty(_applicationContextService?.InputConnectionString))
            {
                return null;
            }

            var conn = new SqlConnection(_applicationContextService.InputConnectionString);
            conn.Open();
            return conn;
        }

        public IDbConnection GetOutputInstance()
        {
            if (string.IsNullOrEmpty(_applicationContextService?.OutputConnectionString))
            {
                return null;
            }

            var conn = new SqlConnection(_applicationContextService.OutputConnectionString);
            conn.Open();
            return conn;
        }
    }
}
