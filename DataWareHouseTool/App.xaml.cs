using System.Windows;
using DataWareHouseTool.DAL.Configuration;
using DataWareHouseTool.DAL.Configuration.Interfaces;
using DataWareHouseTool.DAL.Repositories;
using DataWareHouseTool.DAL.Repositories.Interfaces;
using DataWareHouseTool.Services;
using DataWareHouseTool.Services.Interfaces;
using DataWareHouseTool.ViewModels;
using DataWareHouseTool.ViewModels.Interfaces;
using DataWareHouseTool.Views;
using DataWareHouseTool.Views.Interfaces;
using Microsoft.Practices.Unity;

namespace DataWareHouseTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var unityContainer = new UnityContainer();

            //services
            unityContainer.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IApplicationContextService, ApplicationContextService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ILoggingService, LoggingService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IServerService, ServerService>(new ContainerControlledLifetimeManager());

            //factories
            unityContainer.RegisterType<IConnectionFactory, SqlConnectionFactory>(new ContainerControlledLifetimeManager());

            //repositories
            unityContainer.RegisterType<ISystemDatabaseRepository, SystemDatabaseRepository>(new ContainerControlledLifetimeManager());

            //viewmodels
            unityContainer.RegisterType<IMainViewModel, MainViewModel>();

            //views
            unityContainer.RegisterType<IMainView, MainView>();

            LoadMainPage(unityContainer);
        }

        private static void LoadMainPage(IUnityContainer unityContainer) => unityContainer.Resolve<INavigationService>()?.SetMainView(unityContainer.Resolve<IMainView>());
    }
}
