using NetCoreJenkinsDocker.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreJenkinsDocker.Api.Repositories
{
    public interface ISampleDataRepository
    {
        Task<SampleDataModel> GetData();
    }


    public class SampleDataRepository : ISampleDataRepository
    {
        public async Task<SampleDataModel> GetData()
        {
            await Task.FromResult(0);
            return new SampleDataModel()
            {

            };
        }
    }
}
