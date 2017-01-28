using System.Data;

namespace DataWareHouseTool.DAL.Configuration.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetInputInstance();
        IDbConnection GetOutputInstance();
    }
}