using DDD.Domain.Repositories;
using System;
using DDD.Infrastructure.SQLite;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;

        public WeatherLatestViewModel()
            : this(new WeatherSQLite())
        {
        }

        // 抽象に依存させて中身を入れ替える
        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            _weather = weather;
        }

        private string _areaIdText = string.Empty;
        public string AreaIdText
        {
            get { return _areaIdText; }
            set
            {
                SetProperty(ref _areaIdText, value);
            }
        }

        private string _dataDateText = string.Empty;
        public string DataDateText
        {
            get { return _dataDateText; }
            set
            {
                SetProperty(ref _dataDateText, value);
            }
        }

        private string _conditionText = string.Empty;
        public string ConditionText
        {
            get { return _conditionText; }
            set
            {
                SetProperty(ref _conditionText, value);
            }
        }

        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                SetProperty(ref _temperatureText, value);
            }
        }

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));
            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }
    }
}
