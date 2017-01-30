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
        private readonly IUserPreferenceService _userPreferenceService;

        public MainViewModel(IServerService serverService, IApplicationContextService applicationContextService, ILoggingService loggingService, IUserPreferenceService userPreferenceService)
        {
            _serverService = serverService;
            _applicationContextService = applicationContextService;
            _loggingService = loggingService;
            _userPreferenceService = userPreferenceService;

            ShowOutputServerOption = new AsyncRelayCommand(ShowOutputServerOptionHandler);
            ShowInputServerOption = new AsyncRelayCommand(ShowInputServerOptionHandler);
            DataMigrateCommand = new AsyncRelayCommand(DataMigrateCommandHandler);

            InputServerOption = _userPreferenceService?.InputServerDetails;
            OutputServerOption = _userPreferenceService?.OutputServerDetails;
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

        private async Task ShowInputServerOptionHandler()
        {
        }

        private async Task ShowOutputServerOptionHandler()
        {
        }

        public ObservableCollection<Server> InputServers { get; set; } = new ObservableCollection<Server>();
        public ObservableCollection<Server> OutputServers { get; set; } = new ObservableCollection<Server>();
        public Server SelectedInputServer { get; set; }
        public Server SelectedOutputServer { get; set; }
        public ServerOption OutputServerOption { get; set; } = new ServerOption();
        public ServerOption InputServerOption { get; set; } = new ServerOption();
        public AsyncRelayCommand DataMigrateCommand { get; }
        public AsyncRelayCommand ShowOutputServerOption { get; }
        public AsyncRelayCommand ShowInputServerOption { get; }
        
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