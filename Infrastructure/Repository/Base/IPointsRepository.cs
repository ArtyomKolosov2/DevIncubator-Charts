using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Base
{
    public interface IPointsRepository : IRepository<Point>
    {
        Task<IEnumerable<Point>> GetPointsByUserDataAsync(UserData data);
        Task<int> AddPointsRangeAsync(IEnumerable<Point> points);
        Task<IEnumerable<Point>> GetAllPointsAsync();
    }
}
