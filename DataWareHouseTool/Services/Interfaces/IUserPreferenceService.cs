using System.Threading.Tasks;
using DataWareHouseTool.Entities;

namespace DataWareHouseTool.Services.Interfaces
{
    public interface IUserPreferenceService
    {
        Task<ServerOption> GetInputServerDetailsAsync();
        Task SaveInputServerDetailsAsync(ServerOption serverOption);
        Task<ServerOption> GetOutputServerDetailsAsync();
        Task SaveOutputServerDetailsAsync(ServerOption serverOption);
    }
}