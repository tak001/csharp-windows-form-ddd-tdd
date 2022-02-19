using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    public class WeatherSQLite : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            string sql = @"
select DataDate,
        Condition,
        Temperature
from Weather
where AreaId = @AreaId
order by DataDate desc
LIMIT 1
";

            return SQLiteHelper.QuerySingle(
                sql,
                new List<SQLiteParameter>
                {
                    new SQLiteParameter("@AreaId", areaId)
                }.ToArray(),
                reader =>
                {
                    return new WeatherEntity(
                            areaId,
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                },
                null);
        }

        public IReadOnlyList<WeatherEntity> GetData()
        {
            string sql = @"
select A.AreaId,
         ifnull(B.AreaName,'') as AreaName,
         A.DataDate,
         A.Condition,
         A.Temperature
from Weather A
left outer join Areas B
on A.AreaId = B.AreaId
";

            return SQLiteHelper.Query(sql,
                reader =>
                {
                    return new WeatherEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToString(reader["AreaName"]),
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                });
        }

        public void Save(WeatherEntity weather)
        {
            string insert = @"
insert into Weather
(AreaId,DataDate,Condition,Temperature)
values
(@AreaId,@DataDate,@Condition,@Temperature)
";

            string update = @"
update Weather
set Condition = @Condition,
    Temperature = @Temperature
where AreaId = @AreaId
and DataDate = @DataDate
";

            var args = new List<SQLiteParameter>
            {
                new SQLiteParameter("@AreaId", weather.AreaId.Value),
                new SQLiteParameter("@DataDate", weather.DataDate),
                new SQLiteParameter("@Condition", weather.Condition.Value),
                new SQLiteParameter("@Temperature", weather.Temperature.Value),

            };

            SQLiteHelper.Execute(insert, update, args.ToArray());
        }
    }
}
