using System.ComponentModel;
using System.Threading.Tasks;

namespace DataWareHouseTool.ViewModels.Interfaces
{
    public interface IViewModel : INotifyPropertyChanged
    {
        bool IsBusy { get; }

        bool IsActionsAllowed { get; }

        void BeginBusy(string loadingMessage);

        void EndBusy();

        Task Initialize();
    }
}