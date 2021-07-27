using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rabobank.GCOB.Domain.Implementation.Interface;
using Rabobank.GCOB.Domain.Implementation.Services;
using Rabobank.GCOB.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Rabobank.GCOB.Domain.Implementations.Tests.Unit.Services
{
    [TestClass]
    public class DataProcessorServiceMockTests
    {
        private Mock<IRepository<Interfaces.Models.Client>> _irepository;
        private DataProcessorService _dataProcessorService;

        [TestMethod]
        public void MockRepositoryObject()
        {
            _irepository = new Mock<IRepository<Interfaces.Models.Client>>();

            var expectedValue = new Task<bool>(() => { return false; });
            expectedValue.Start();

            var actualValue = _irepository.Object.Update(new Interfaces.Models.Client()).Result;

            Assert.AreEqual(expectedValue.Result, actualValue);
        }

        [TestMethod]
        public void CallServiceClass_MockObject()
        {
            _irepository = new Mock<IRepository<Interfaces.Models.Client>>();

            var expectedValue = new Task<bool>(() => { return true; });
            expectedValue.Start();

            _irepository.Setup(x => x.Update(new Interfaces.Models.Client())).Returns(expectedValue);

            _dataProcessorService = new DataProcessorService(_irepository.Object);

            var isDataProcessed = _dataProcessorService.ProcessData().GetAwaiter().GetResult();

            Assert.IsTrue(isDataProcessed);
        }
    }
}
