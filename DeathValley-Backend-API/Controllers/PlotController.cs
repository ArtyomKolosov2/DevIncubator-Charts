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
    /// <summary>
    /// Plot controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly IChartPointsService _getChartPointsService;
        /// <summary>
        /// Configuring controller with help of DI
        /// </summary>
        /// <param name="getChartPointsService"></param>
        public PlotController(IChartPointsService getChartPointsService)
        {
            _getChartPointsService = getChartPointsService;
        }

        /// <summary>
        /// Get list of chart points
        /// </summary>
        /// <remarks>Allows anonymous users</remarks>
        /// <param name="viewModel">Contains data from front-end</param>
        /// <returns>
        /// List of chart points
        /// </returns>
        /// <response code="200">If calculation success</response>
        /// <response code="204">If query was succesfull, but something went wrong</response>
        /// <response code="401">If model validation errors</response>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<PointViewModel>>> GetPoints([FromBody] PlotViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userData = new UserData(viewModel);
                var points = await _getChartPointsService.GetPointsByUserDataAsync(userData);
                if (points.Any())
                {
                    return Ok(from p in points
                              orderby p.PointX
                              select new PointViewModel{X = p.PointX, Y = p.PointY });
                }

                return NoContent();    
            }
            return ValidationProblem();
        }
    }
}
