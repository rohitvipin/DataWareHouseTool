namespace DataWareHouseTool.Services.Interfaces
{
    public interface IDbConnectionService
    {
        bool IsConnectionAvailable(string connectionString);
    }
}