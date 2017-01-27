using System.Threading.Tasks;
using System.Windows;
using DataWareHouseTool.ViewModels.Interfaces;
using DataWareHouseTool.Views.Interfaces;

namespace DataWareHouseTool.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window, IMainView
    {
        private readonly IMainViewModel _mainViewModel;

        public MainView(IMainViewModel mainViewModel)
        {
            InitializeComponent();

            DataContext = _mainViewModel = mainViewModel;
        }

        public async Task Initialize()
        {
            var initialize = _mainViewModel?.Initialize();
            if (initialize != null)
            {
                await initialize;
            }
        }
    }
}
