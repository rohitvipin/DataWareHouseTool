using System.Threading.Tasks;
using System.Windows;
using DataWareHouseTool.Services.Interfaces;
using DataWareHouseTool.Views.Interfaces;

namespace DataWareHouseTool.Services
{
    public class NavigationService : INavigationService
    {
        public async Task SetMainView(IView view)
        {
            var initialize = view?.Initialize();
            if (initialize != null)
            {
                await initialize;
                (view as Window)?.Show();
            }
        }
    }
}