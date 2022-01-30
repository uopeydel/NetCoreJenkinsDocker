using Moq;
using NetCoreJenkinsDocker.Api.Models;
using NetCoreJenkinsDocker.Api.Repositories;
using NetCoreJenkinsDocker.Api.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NetCoreJenkinsDocker.xTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var aObject = new SampleDataModel();
            aObject.Id = 4;
            aObject. Age = 3;
            aObject.Name = "test";
            ValidationContext context = new ValidationContext(aObject, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(aObject, context, validationResults, true);

            if (isValid == false)
            {
                var ValidateResultTextsx = validationResults.SelectMany(s => s.MemberNames).ToList();
            }
            var ValidateResultTexts = validationResults.SelectMany(s => s.MemberNames).ToList();
            Assert.True(isValid);
        }

        private Mock<ISampleDataRepository> _sampleDataRepoMocking;

        [Fact]
        public async Task Test2()
        {
            var mock = new MockRepository(MockBehavior.Default);
            _sampleDataRepoMocking = new Mock<ISampleDataRepository>();

            _sampleDataRepoMocking
                .Setup(s => s.GetData())
                .Returns(Task.FromResult(new SampleDataModel { Id = 3, Age = 6, Name = "natest" }));

            var service = new SampleDataService(_sampleDataRepoMocking.Object);
            var serviceResult = await service.GetData();




            ValidationContext context = new ValidationContext(serviceResult, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(serviceResult, context, validationResults, true);

            if (isValid == false)
            {
                var ValidateResultTextsx = validationResults.SelectMany(s => s.MemberNames).ToList();
            }
            var ValidateResultTexts = validationResults.SelectMany(s => s.MemberNames).ToList();
            Assert.True(isValid);
        }
    }
}
