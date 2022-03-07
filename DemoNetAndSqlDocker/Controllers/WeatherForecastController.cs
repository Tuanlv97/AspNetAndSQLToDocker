using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoNetAndSqlDocker.Entities;
using DemoNetAndSqlDocker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoNetAndSqlDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ColourContext context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ColourContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Colour>> GetCoulourItems()
        {
            return context.ColourItems;
        }

        [HttpPost]
        public async Task<IActionResult> PostCoulourItems(ColourModel item)
        {
            var colour = new Colour
            {
                ColourName = item.ColourName
            };

            context.ColourItems.Add(colour);
            var result = await context.SaveChangesAsync();
            if (result > 0)
                return Ok();
            else
                return BadRequest("Lỗi");

        }
    }
}
