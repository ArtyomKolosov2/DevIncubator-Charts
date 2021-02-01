using Core.Models;
using Infrastructure.Context;
using Infrastructure.Services.Base;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Infrastructure.Services
{
    public class CalculatePointsService : ICalculatePoints
    {
        private readonly IMemoryCache _memoryCache;
        private readonly AppDbContext _appDbContext;
        public CalculatePointsService(IMemoryCache memoryCache, AppDbContext appDbContext)
        {
            _memoryCache = memoryCache;
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Point>> CalculatePointsByUserDataAsync(UserData data)
        {
            var points = await Task.Run(() => CalculatePointsByUserData(data));
            _appDbContext.Points.AddRange(points);
            var savedAmount = await _appDbContext.SaveChangesAsync();
            if (savedAmount > 0)
            {
                _memoryCache.Set(data.UserDataId, points, new MemoryCacheEntryOptions 
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });
            }
            return points;
        }

        private IEnumerable<Point> CalculatePointsByUserData(UserData data)
        {
            var resultList = new List<Point>();
            for (double currentX = data.RangeFrom; currentX <= data.RangeTo; currentX += data.Step)
            {
                resultList.Add(new Point
                {
                    PointX = (int)currentX,
                    PointY = (int)CalculateFunction(currentX, data.A, data.B, data.C),
                    ChartId = data.UserDataId
                }
                );
            }
            return resultList;
        }

        private double CalculateFunction(double currentX, int a, int b, int c)
        {
            return a * Pow(currentX, 2) + b * currentX + c;
        }
    }
}
