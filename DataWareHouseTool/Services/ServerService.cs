using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataWareHouseTool.DAL.Configuration.Interfaces;
using DataWareHouseTool.DAL.Repositories.Interfaces;
using DataWareHouseTool.Entities;
using DataWareHouseTool.Helpers;
using DataWareHouseTool.Services.Interfaces;

namespace DataWareHouseTool.Services
{
    public class ServerService : IServerService
    {
        private readonly IApplicationContextService _applicationContextService;
        private readonly IConnectionFactory _connectionFactory;
        private readonly ISystemDatabaseRepository _systemDatabaseRepository;

        public ServerService(IConnectionFactory connectionFactory, ISystemDatabaseRepository systemDatabaseRepository, IApplicationContextService applicationContextService)
        {
            _connectionFactory = connectionFactory;
            _systemDatabaseRepository = systemDatabaseRepository;
            _applicationContextService = applicationContextService;
        }

        private static string GetConnectionString(Server server, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(server?.Name))
            {
                return null;
            }

            var start = connectionString.IndexOf("Initial Catalog=", StringComparison.InvariantCultureIgnoreCase);
            var end = connectionString.IndexOf(";Persist Security Info", StringComparison.InvariantCultureIgnoreCase);

            //I skip the check that end is valid too avoid clutter
            return $"{connectionString.Substring(0, start)}{server.Name}{connectionString.Substring(end + 1)}";
        }

        public async Task<IEnumerable<Server>> GetAllInputServers()
        {
            if (_systemDatabaseRepository == null)
            {
                return null;
            }

            _systemDatabaseRepository.DbConnection = _connectionFactory?.GetInputInstance();
            var task = _systemDatabaseRepository.Get();
            return task != null ? Converter.To(await task) : null;
        }

        public async Task<IEnumerable<Server>> GetAllOutputServers()
        {
            if (_systemDatabaseRepository == null)
            {
                return null;
            }

            _systemDatabaseRepository.DbConnection = _connectionFactory?.GetOutputInstance();
            var task = _systemDatabaseRepository.Get();
            return task != null ? Converter.To(await task) : null;
        }

        public string GetInputConnectionString(Server server) => GetConnectionString(server, _applicationContextService?.InputConnectionString);

        public string GetOutputConnectionString(Server server) => GetConnectionString(server, _applicationContextService?.OutputConnectionString);
    }
}