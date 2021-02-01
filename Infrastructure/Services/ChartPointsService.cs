using Core.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Base;
using Infrastructure.Services.Base;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Infrastructure.Services
{
    public class ChartPointsService : IChartPointsService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IPointsRepository _pointsRepository;
        private readonly IUserDataRepository _userDataRepository;
        public ChartPointsService(IMemoryCache memoryCache, IPointsRepository pointsRepository, IUserDataRepository userDataRepository)
        {
            _memoryCache = memoryCache;
            _pointsRepository = pointsRepository;
            _userDataRepository = userDataRepository;
        }
        public async Task<IEnumerable<Point>> GetPointsByUserDataAsync(UserData data)
        {
            var userData = await _userDataRepository.TryToGetDuplicatedUserDataAsync(data);
            IEnumerable<Point> points;
            if (userData != null)
            {
                if (!_memoryCache.TryGetValue(data.UserDataId, out points))
                {
                    points = await _pointsRepository.GetPointsByUserDataAsync(userData);
                }
            }
            else
            {
                points = CalculatePointsByUserData(userData);
                SavePointsToCache(userData, points);
                await _pointsRepository.AddPointsRangeAsync(points);
            }

            return points;
        }

        private void SavePointsToCache(UserData data, IEnumerable<Point> points)
        {
            _memoryCache.Set(data.UserDataId, points, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
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
