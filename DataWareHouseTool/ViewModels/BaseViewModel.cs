using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DataWareHouseTool.ViewModels.Interfaces;

namespace DataWareHouseTool.ViewModels
{
    public abstract class BaseViewModel : IViewModel
    {
        private int _busyTaskCount;

        public abstract Task Initialize();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool IsBusy => _busyTaskCount != 0;

        public bool IsActionsAllowed => _busyTaskCount == 0;

        public void BeginBusy(string loadingMessage)
        {
            _busyTaskCount++;
        }

        public void EndBusy()
        {
            if (_busyTaskCount > 0)
            {
                _busyTaskCount--;
            }
        }
    }
}