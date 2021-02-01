using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Base
{
    public interface ICalculatePoints
    {
        public Task<IEnumerable<Point>> CalculatePointsByUserDataAsync(UserData data);
    }
}
