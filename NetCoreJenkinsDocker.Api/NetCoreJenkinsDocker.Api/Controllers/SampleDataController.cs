using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreJenkinsDocker.Api.DataAccess;
using NetCoreJenkinsDocker.Api.Helper;
using NetCoreJenkinsDocker.Api.Models;
using Swashbuckle.AspNetCore.Annotations;
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
        private readonly NCJDDbContext _dbContext;
        public SampleDataController(ILogger<WeatherForecastController> logger, NCJDDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SampleDataModel request)
        {
            await _dbContext.SampleDatas.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            await Task.FromResult(0);
            return Ok(request);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] SampleDataModel request)
        {
            _dbContext.SampleDatas.Update(request);
            await _dbContext.SaveChangesAsync();
            await Task.FromResult(0);
            return Ok(request);
        }
        /*

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var cha = await _dbContext
                .SampleDatas
                .Include(c => c.Items)
                .AsNoTracking()
                .ToListAsync();

            return Ok(cha);
        }

        */

        [SwaggerResponse(StatusCodes.Status200OK, "Returns success status code with content", typeof(NCJDResult<List<SampleDataModel>>))]
        [HttpPost("Read")]
        public async Task<IActionResult> Read()
        {
            var cha = await _dbContext
                .SampleDatas
                .AsNoTracking()
                .ToListAsync();

            var itm = await _dbContext
                .Items
                .AsNoTracking()
                .ToListAsync();

            cha.ForEach(f =>
            {
                f.Items = itm.Where(w => w.SampleDataId == f.Id).ToHashSet();
            });

            
            return Ok(NCJDResponse.Success(cha));
        }
    }
}
