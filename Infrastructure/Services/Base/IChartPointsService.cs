using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Base
{
    public interface IChartPointsService
    {
        public Task<IEnumerable<Point>> GetPointsByUserDataAsync(UserData data);
    }
}
