using System.Threading.Tasks;
using DataWareHouseTool.ViewModels.Interfaces;

namespace DataWareHouseTool.ViewModels
{
    public abstract class BaseViewModel : IViewModel
    {
        public abstract Task Initialize();
    }
}