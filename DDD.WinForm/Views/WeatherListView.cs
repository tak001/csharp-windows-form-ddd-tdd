using DDD.WinForm.ViewModels;
using System.Windows.Forms;

namespace DDD.WinForm.Views
{
    public partial class WeatherListView : Form
    {
        private WeatherListViewModel _viewModel = new WeatherListViewModel();
        public WeatherListView()
        {
            InitializeComponent();

            WeathersDataGrid.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Weathers));
        }
    }
}
