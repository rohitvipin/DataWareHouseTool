using System.Threading.Tasks;
using DataWareHouseTool.Views.Interfaces;

namespace DataWareHouseTool.Services.Interfaces
{
    public interface INavigationService
    {
        Task SetMainView(IView view);
    }
}