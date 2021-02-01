using Core.Models;
using Core.ViewModels;
using Infrastructure.Context;
using Infrastructure.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeathValley_Backend_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly ICalculatePoints _calculatePoints;
        private readonly IMemoryCache _memoryCache;
        private readonly AppDbContext _appDbContext;
        public PlotController(ICalculatePoints calculatePoints, IMemoryCache memoryCache, AppDbContext appDbContext)
        {
            _calculatePoints = calculatePoints;
            _memoryCache = memoryCache;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Point>>> GetPoints([FromBody] PlotViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userData = await _appDbContext.UserDatas.FirstOrDefaultAsync
                (
                    userData =>
                    userData.A == viewModel.A &&
                    userData.B == viewModel.B &&
                    userData.C == viewModel.C &&
                    userData.RangeTo == viewModel.RangeTo &&
                    userData.RangeFrom == viewModel.RangeFrom
                );
                if (userData is not null)
                {
                    if (_memoryCache.TryGetValue(userData.UserDataId, out IEnumerable<Point> points))
                    {
                        return Ok(points);
                    }
                    points = await _appDbContext.Points.Where(point => point.ChartId == userData.UserDataId).ToListAsync();
                    if (points.Any())
                    {
                        _memoryCache.Set(userData.UserDataId, points, new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                        });
                    }
                    return Ok(points);
                }
                else
                {
                    var newUserData = new UserData
                    {
                        A = viewModel.A,
                        B = viewModel.B,
                        C = viewModel.C,
                        RangeFrom = viewModel.RangeFrom,
                        RangeTo = viewModel.RangeTo,
                        Step = viewModel.Step,
                    };
                    _appDbContext.UserDatas.Add(newUserData);
                    await _appDbContext.SaveChangesAsync();
                    return Ok(await _calculatePoints.CalculatePointsByUserDataAsync(newUserData));
                }
            }

            return ValidationProblem();
        }
    }
}
