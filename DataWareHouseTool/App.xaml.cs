using System.Windows;
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
            
            //viewmodels
            unityContainer.RegisterType<IMainViewModel, MainViewModel>();

            //views
            unityContainer.RegisterType<IMainView, MainView>();

            LoadMainPage(unityContainer);
        }

        private static async void LoadMainPage(IUnityContainer unityContainer)
        {
            var mainView = unityContainer.Resolve<INavigationService>()?.SetMainView(unityContainer.Resolve<IMainView>());
            if (mainView != null)
            {
                await mainView;
            }
        }
    }
}
