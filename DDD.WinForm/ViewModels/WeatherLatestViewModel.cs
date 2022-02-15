using DDD.Domain.Repositories;
using System;
using DDD.Infrastructure.SQLite;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel : INotifyPropertyChanged
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
                if (_areaIdText == value)
                {
                    return;
                }

                _areaIdText = value;
                OnPropertyChanged(nameof(AreaIdText));
            }
        }

        private string _dataDateText = string.Empty;
        public string DataDateText
        {
            get { return _dataDateText; }
            set
            {
                if (_dataDateText == value)
                {
                    return;
                }

                _dataDateText = value;
                OnPropertyChanged(nameof(DataDateText));
            }
        }

        private string _conditionText = string.Empty;
        public string ConditionText
        {
            get { return _conditionText; }
            set
            {
                if (_conditionText == value)
                {
                    return;
                }

                _conditionText = value;
                OnPropertyChanged(nameof(ConditionText));
            }
        }

        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                if (_temperatureText == value)
                {
                    return;
                }

                _temperatureText = value;
                OnPropertyChanged(nameof(TemperatureText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
