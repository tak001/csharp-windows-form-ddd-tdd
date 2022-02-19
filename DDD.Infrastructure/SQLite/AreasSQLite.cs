using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    public sealed class AreasSQLite : IAreasRepository
    {
        public IReadOnlyList<AreaEntity> GetData()
        {
            string sql = @"
select  AreaId,
        AreaName
from Areas";

            var result = new List<AreaEntity>();
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new AreaEntity(Convert.ToInt32(reader["AreaId"]),
                                                 Convert.ToString(reader["AreaName"])));
                    }
                }
            }

            return result.AsReadOnly();
        }
    }
}
