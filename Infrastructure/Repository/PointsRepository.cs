using Core.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PointsRepository : Repository<Point>, IPointsRepository
    {
        private readonly AppDbContext _appDbContext;
        public PointsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> AddPointsRange(IEnumerable<Point> points)
        {
            await _appDbContext.AddRangeAsync(points);
            return await _appDbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Point>> GetAllPoints() => GetItemsList();

        public async Task<IEnumerable<Point>> GetPointsByUserData(UserData data)
        {
            return await _appDbContext.Points.Where(point => point.ChartId == data.UserDataId).ToListAsync();
        }
    }
}
