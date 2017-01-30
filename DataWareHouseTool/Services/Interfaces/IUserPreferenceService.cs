using DataWareHouseTool.Entities;

namespace DataWareHouseTool.Services.Interfaces
{
    public interface IUserPreferenceService
    {
        ServerOption InputServerDetails { get; set; }
        ServerOption OutputServerDetails { get; set; }
    }
}