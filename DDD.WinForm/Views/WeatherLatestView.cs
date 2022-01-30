using System.Data.SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DDD.WinForm.Common;
using DDD.WinForm.Common.Data;

namespace DDD.WinForm
{
    public partial class WeatherLatestView : Form
    {
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
