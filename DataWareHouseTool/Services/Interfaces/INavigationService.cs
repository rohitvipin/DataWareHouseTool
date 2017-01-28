using DataWareHouseTool.Views.Interfaces;

namespace DataWareHouseTool.Services.Interfaces
{
    public interface INavigationService
    {
        void SetMainView(IView view);
    }
}