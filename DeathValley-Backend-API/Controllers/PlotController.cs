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
        private readonly IChartPointsService _calculatePoints;
        public PlotController(IChartPointsService calculatePoints)
        {
            _calculatePoints = calculatePoints;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Point>>> GetPoints([FromQuery] PlotViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userData = new UserData
                {
                    A = viewModel.A,
                    B = viewModel.B,
                    C = viewModel.C,
                    RangeFrom = viewModel.RangeFrom,
                    RangeTo = viewModel.RangeTo
                };
                var points = await _calculatePoints.GetPointsByUserDataAsync(userData);
                if (points.Any())
                {
                    return Ok(points);
                }
                else
                {
                    return NoContent();
                }
            }

            return ValidationProblem();
        }
    }
}
