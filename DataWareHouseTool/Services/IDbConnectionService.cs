using DataWareHouseTool.DAL.Configuration.Interfaces;
using DataWareHouseTool.Services.Interfaces;

namespace DataWareHouseTool.Services
{
    public class DbConnectionService : IDbConnectionService
    {
        private readonly IConnectionFactory _connectionFactory;

        public DbConnectionService(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public bool IsConnectionAvailable(string connectionString) => _connectionFactory?.IsConnectionAvailable(connectionString) ?? false;
    }
}