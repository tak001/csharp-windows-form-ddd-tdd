using DDD.Domain.Entities;
using System.Collections.Generic;

namespace DDD.Domain.Repositories
{
    public interface IWeatherRepository
    {
        WeatherEntity GetLatest(int areaId);
        IReadOnlyList<WeatherEntity> GetData();
        void Save(WeatherEntity weather);
    }
}
