using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        private IAreasRepository _areas;

        public WeatherSaveViewModel(IAreasRepository areas)
        {
            _areas = areas;
            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = string.Empty;

            foreach (var area in _areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        public object SelectedAreaId { get; set; }
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureText { get; set; }
        public BindingList<AreaEntity> Areas { get; set; }
        = new BindingList<AreaEntity>();

        public BindingList<Condition> Conditions { get; set; }
        = new BindingList<Condition>(Condition.ToList());

        public void Save()
        {
            if (SelectedAreaId == null)
            {
                throw new InputException("エリアを選択して下さい");
            }
        }
    }
}
