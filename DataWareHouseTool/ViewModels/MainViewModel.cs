using System;
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
        private readonly ILoggingService _loggingService;

        public MainViewModel(IServerService serverService, IApplicationContextService applicationContextService, ILoggingService loggingService)
        {
            _serverService = serverService;
            _applicationContextService = applicationContextService;
            _loggingService = loggingService;
            ShowOutputServerOptions = new AsyncRelayCommand(ShowOutputServerOptionsHandler);
            ShowInputServerOptions = new AsyncRelayCommand(ShowInputServerOptionsHandler);
            DataMigrateCommand = new AsyncRelayCommand(DataMigrateCommandHandler);
        }

        private async Task DataMigrateCommandHandler()
        {
            try
            {
                if (SelectedInputServer != null && SelectedOutputServer != null && _serverService != null && _applicationContextService != null)
                {
                    _applicationContextService.OutputConnectionString = _serverService.GetOutputConnectionString(SelectedOutputServer);
                    _applicationContextService.InputConnectionString = _serverService.GetInputConnectionString(SelectedInputServer);
                }
            }
            catch (Exception exception)
            {
                _loggingService?.Log(exception);
            }
        }

        private async Task ShowInputServerOptionsHandler()
        {
        }

        private async Task ShowOutputServerOptionsHandler()
        {
        }

        public ObservableCollection<Server> InputServers { get; set; } = new ObservableCollection<Server>();
        public ObservableCollection<Server> OutputServers { get; set; } = new ObservableCollection<Server>();
        public Server SelectedInputServer { get; set; }
        public Server SelectedOutputServer { get; set; }
        public ServerOptions OutputServerOptions { get; set; } = new ServerOptions();
        public ServerOptions InputServerOptions { get; set; } = new ServerOptions();
        public AsyncRelayCommand DataMigrateCommand { get; }
        public AsyncRelayCommand ShowOutputServerOptions { get; }
        public AsyncRelayCommand ShowInputServerOptions { get; }
        
        public override async Task Initialize()
        {
            try
            {
                var allInputServers = _serverService?.GetAllInputServers();
                var allOutputServers = _serverService?.GetAllOutputServers();

                if (allInputServers != null)
                {
                    var servers = await allInputServers;
                    if (servers != null)
                    {
                        InputServers = new ObservableCollection<Server>(servers);
                    }
                }
                if (allOutputServers != null)
                {
                    var servers = await allOutputServers;
                    if (servers != null)
                    {
                        OutputServers = new ObservableCollection<Server>(servers);
                    }
                }
            }
            catch (Exception exception)
            {
                _loggingService?.Log(exception);
            }
        }
    }
}