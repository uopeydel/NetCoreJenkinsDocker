using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreJenkinsDocker.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreJenkinsDocker.Api.Controllers
{
    [ApiController]
    [Route("api/SampleData")]
    public class SampleDataController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public SampleDataController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Get(SampleDataModel aObj)
        {
            await Task.FromResult(0);
            return Ok(aObj);
        }
    }
}
