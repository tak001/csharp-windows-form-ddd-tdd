using System;
using System.Windows.Forms;
using DDD.WinForm.ViewModels;

namespace DDD.WinForm
{
    public partial class WeatherLatestView : Form
    {
        private WeatherLatestViewModel _viewModel = new WeatherLatestViewModel();
        public WeatherLatestView()
        {
            InitializeComponent();
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            //var dt = WeatherSQLite.GetLatest(Convert.ToInt32(AreaIdTextBox.Text));
        }

    }
}
