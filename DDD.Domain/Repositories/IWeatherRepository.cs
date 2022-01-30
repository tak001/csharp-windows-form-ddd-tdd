using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories
{
    public interface IWeatherRepository
    {
        DataTable GetLatest(int areaId);
    }
}
