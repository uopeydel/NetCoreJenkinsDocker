using NetCoreJenkinsDocker.Api.Models;
using NetCoreJenkinsDocker.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreJenkinsDocker.Api.Services
{
    public interface ISampleDataService
    {
        Task<SampleDataModel> GetData();
    }

    public class SampleDataService : ISampleDataService
    {
        private readonly ISampleDataRepository _repo;
        public SampleDataService(ISampleDataRepository repo)
        {
            _repo = repo;
        }

        public async Task<SampleDataModel> GetData()
        {
            return await _repo.GetData();
        }
    }
}
