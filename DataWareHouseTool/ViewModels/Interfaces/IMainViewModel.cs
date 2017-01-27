using System.Collections.Generic;
using DataWareHouseTool.Common;
using DataWareHouseTool.Entities;

namespace DataWareHouseTool.ViewModels.Interfaces
{
    public interface IMainViewModel : IViewModel
    {
        List<Server> InputServers { get; set; }
        List<Server> OutputServers { get; set; }
        AsyncRelayCommand DataMigrateCommand { get; }
    }
}