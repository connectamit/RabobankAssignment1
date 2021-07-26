using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rabobank.GCOB.Domain.Implementation.Interface;
using Rabobank.GCOB.Domain.Implementation.Services;
using Rabobank.GCOB.Domain.Interfaces.Repositories;
using System;

namespace Rabobank.GCOB.Domain.Implementations.Tests.Unit.Services
{
    [TestClass]
    public class DataProcessorServiceTests
    {
        private DataProcessorService _dataProcessorService;
        private IRepository<Interfaces.Models.Client> _irepository;

        [TestInitialize]
        public void Test_SetUp()
        {
            _irepository = new Repository<Interfaces.Models.Client>();
            _dataProcessorService = new DataProcessorService(_irepository);
        }

        [TestMethod]
        public void ProcessData()
        {
            var isDataProcessed = _dataProcessorService.ProcessData().GetAwaiter().GetResult();

            Assert.IsTrue(isDataProcessed);

        }
    }
}
