using System.Collections.Generic;
using System.Threading.Tasks;
using DataWareHouseTool.Common;
using DataWareHouseTool.Entities;
using DataWareHouseTool.ViewModels.Interfaces;

namespace DataWareHouseTool.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        public MainViewModel()
        {
            DataMigrateCommand = new AsyncRelayCommand(DataMigrateCommandHandler);
        }

        public List<Server> InputServers { get; set; }
        public List<Server> OutputServers { get; set; }
        public AsyncRelayCommand DataMigrateCommand { get; }

        private async Task DataMigrateCommandHandler()
        {

        }

        public override async Task Initialize()
        {
            InputServers = new List<Server> { new Server { Id = 1, Name = "1" }, new Server { Id = 2, Name = "2" }, new Server { Id = 3, Name = "3" }, new Server { Id = 4, Name = "4" } };
            OutputServers = new List<Server> { new Server { Id = 1, Name = "1" }, new Server { Id = 2, Name = "2" }, new Server { Id = 3, Name = "3" }, new Server { Id = 4, Name = "4" } };
        }
    }
}