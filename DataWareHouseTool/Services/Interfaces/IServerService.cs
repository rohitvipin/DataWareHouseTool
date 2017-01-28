using System.Collections.Generic;
using System.Threading.Tasks;
using DataWareHouseTool.Entities;

namespace DataWareHouseTool.Services.Interfaces
{
    public interface IServerService
    {
        Task<IEnumerable<Server>> GetAllInputServers();
        Task<IEnumerable<Server>> GetAllOutputServers();
        string GetInputConnectionString(Server server);
        string GetOutputConnectionString(Server server);
    }
}