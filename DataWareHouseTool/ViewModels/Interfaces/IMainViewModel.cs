using System.Collections.ObjectModel;
using DataWareHouseTool.Common;
using DataWareHouseTool.Entities;

namespace DataWareHouseTool.ViewModels.Interfaces
{
    public interface IMainViewModel : IViewModel
    {
        ObservableCollection<Server> InputServers { get; set; }
        ObservableCollection<Server> OutputServers { get; set; }
        Server SelectedOutputServer { get; set; }
        Server SelectedInputServer { get; set; }
        ServerOptions OutputServerOptions { get; set; }
        ServerOptions InputServerOptions { get; set; }
        AsyncRelayCommand DataMigrateCommand { get; }
        AsyncRelayCommand ShowOutputServerOptions { get; }
        AsyncRelayCommand ShowInputServerOptions { get; }
    }
}