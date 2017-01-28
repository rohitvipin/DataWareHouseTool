using System.Threading.Tasks;
using System.Windows;
using DataWareHouseTool.Services.Interfaces;
using DataWareHouseTool.Views.Interfaces;

namespace DataWareHouseTool.Services
{
    public class NavigationService : INavigationService
    {
        public void SetMainView(IView view)
        {
            var initialize = view?.Initialize();
            if (initialize == null)
            {
                return;
            }

            (view as Window)?.Show();
            Task.Run(async () => await initialize);
        }
    }
}