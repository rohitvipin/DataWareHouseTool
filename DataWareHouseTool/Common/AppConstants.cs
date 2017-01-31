namespace DataWareHouseTool.Common
{
    public static class AppConstants
    {
        public const string ConnectionString = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2}; Password={3}";
        public const string ConnectionStringWithoutDbName = "Data Source={0};Persist Security Info=True;User ID={1}; Password={2}";
    }
}