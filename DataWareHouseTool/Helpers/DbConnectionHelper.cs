using DataWareHouseTool.Common;

namespace DataWareHouseTool.Helpers
{
    public static class DbConnectionHelper
    {
        public static string GetConnectionString(string serverName, string databaseName, string userName, string password) => string.Format(AppConstants.ConnectionString, serverName, databaseName, userName, password);
        public static string GetConnectionString(string serverName, string userName, string password) => string.Format(AppConstants.ConnectionStringWithoutDbName, serverName, userName, password);
    }
}