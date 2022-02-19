using System;

namespace DDD.WinForm.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        public WeatherSaveViewModel()
        {
            DataDateValue = DateTime.Now;
        }

        public object SelectedAreaId { get; set; }
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureText { get; set; }
    }
}
