using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using DataWareHouseTool.Common;
using DataWareHouseTool.Entities;
using DataWareHouseTool.Helpers;
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
        private readonly IDbConnectionService _dbConnectionService;
        private Server _selectedInputServer;
        private Server _selectedOutputServer;
        private ServerOption _inputServerOption;
        private ServerOption _outputServerOption;

        public MainViewModel(IServerService serverService, IApplicationContextService applicationContextService, ILoggingService loggingService, IUserPreferenceService userPreferenceService, IDbConnectionService dbConnectionService)
        {
            _serverService = serverService;
            _applicationContextService = applicationContextService;
            _loggingService = loggingService;
            _userPreferenceService = userPreferenceService;
            _dbConnectionService = dbConnectionService;

            DataMigrateCommand = new AsyncRelayCommand(DataMigrateCommandHandler);
            ConnectToOutputServer = new AsyncRelayCommand(ConnectToOutputServerHandler);
            ConnectToInputServer = new AsyncRelayCommand(ConnectToInputServerHandler);
        }

        private static void ShowConnectionError() => MessageBox.Show("Connection to server failed!", "Connection Error", MessageBoxButton.OK);

        private bool IsConnectionSuccessfull(ServerOption serverOption) => serverOption != null && (_dbConnectionService?.IsConnectionAvailable(DbConnectionHelper.GetConnectionString(serverOption.ServerName, serverOption.Username, serverOption.Password)) ?? false);

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

        private async Task ConnectToInputServerHandler()
        {
            try
            {
                if (IsConnectionSuccessfull(InputServerOption))
                {
                    var saveInputServerDetailsAsync = _userPreferenceService?.SaveInputServerDetailsAsync(InputServerOption);
                    if (saveInputServerDetailsAsync != null)
                    {
                        await saveInputServerDetailsAsync;
                    }
                    return;
                }
                ShowConnectionError();
            }
            catch (Exception exception)
            {
                _loggingService?.Log(exception);
            }
        }

        private async Task ConnectToOutputServerHandler()
        {
            try
            {
                if (IsConnectionSuccessfull(InputServerOption))
                {
                    var saveInputServerDetailsAsync = _userPreferenceService?.SaveInputServerDetailsAsync(InputServerOption);
                    if (saveInputServerDetailsAsync != null)
                    {
                        await saveInputServerDetailsAsync;
                    }
                }
                ShowConnectionError();
            }
            catch (Exception exception)
            {
                _loggingService?.Log(exception);
            }
        }

        public ObservableCollection<Server> InputServers { get; set; } = new ObservableCollection<Server>();
        public ObservableCollection<Server> OutputServers { get; set; } = new ObservableCollection<Server>();

        public Server SelectedInputServer
        {
            get { return _selectedInputServer; }
            set
            {
                _selectedInputServer = value;
                OnPropertyChanged();
            }
        }

        public Server SelectedOutputServer
        {
            get { return _selectedOutputServer; }
            set
            {
                _selectedOutputServer = value;
                OnPropertyChanged();
            }
        }

        public ServerOption OutputServerOption
        {
            get { return _outputServerOption; }
            set
            {
                _outputServerOption = value;
                OnPropertyChanged();
            }
        }

        public ServerOption InputServerOption
        {
            get { return _inputServerOption; }
            set
            {
                _inputServerOption = value;
                OnPropertyChanged();
            }
        }

        public AsyncRelayCommand DataMigrateCommand { get; }
        public AsyncRelayCommand ConnectToInputServer { get; }
        public AsyncRelayCommand ConnectToOutputServer { get; }

        public override async Task Initialize()
        {
            try
            {
                var allInputServers = _serverService?.GetAllInputServers();
                var allOutputServers = _serverService?.GetAllOutputServers();

                var inputServerDetailsAsync = _userPreferenceService?.GetInputServerDetailsAsync();
                var outputServerDetailsAsync = _userPreferenceService?.GetOutputServerDetailsAsync();

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

                if (inputServerDetailsAsync != null)
                {
                    InputServerOption = await inputServerDetailsAsync;
                }
                if (outputServerDetailsAsync != null)
                {
                    OutputServerOption = await outputServerDetailsAsync;
                }
            }
            catch (Exception exception)
            {
                _loggingService?.Log(exception);
            }
        }
    }
}