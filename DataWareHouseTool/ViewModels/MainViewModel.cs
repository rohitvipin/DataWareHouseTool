using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DataWareHouseTool.Common;
using DataWareHouseTool.Entities;
using DataWareHouseTool.Services.Interfaces;
using DataWareHouseTool.ViewModels.Interfaces;

namespace DataWareHouseTool.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private readonly IServerService _serverService;
        private readonly IApplicationContextService _applicationContextService;

        public MainViewModel(IServerService serverService, IApplicationContextService applicationContextService)
        {
            _serverService = serverService;
            _applicationContextService = applicationContextService;
            DataMigrateCommand = new AsyncRelayCommand(DataMigrateCommandHandler);
        }

        public ObservableCollection<Server> InputServers { get; set; } = new ObservableCollection<Server>();
        public ObservableCollection<Server> OutputServers { get; set; } = new ObservableCollection<Server>();
        public Server SelectedInputServer { get; set; }
        public Server SelectedOutputServer { get; set; }
        public AsyncRelayCommand DataMigrateCommand { get; }

        private async Task DataMigrateCommandHandler()
        {
            if (SelectedInputServer != null && SelectedOutputServer != null && (_serverService != null && _applicationContextService != null))
            {
                _applicationContextService.OutputConnectionString = _serverService.GetOutputConnectionString(SelectedOutputServer);
            }
        }

        public override async Task Initialize()
        {
            var allInputServers = _serverService?.GetAllInputServers();
            var allOutputServers = _serverService?.GetAllOutputServers();

            if (allInputServers != null)
            {
                InputServers = new ObservableCollection<Server>(await allInputServers);
            }
            if (allOutputServers != null)
            {
                OutputServers = new ObservableCollection<Server>(await allOutputServers);
            }
        }


    }
}