using System.Data;
using DataWareHouseTool.DAL.Models;

namespace DataWareHouseTool.DAL.Repositories.Interfaces
{
    public interface ISystemDatabaseRepository : IRepository<SystemDatabase>
    {
        IDbConnection DbConnection { get; set; }

    }
}