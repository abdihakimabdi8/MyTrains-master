using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.UnitTests.Mocks;
using System.Threading.Tasks;

namespace MyTrains.Core.UnitTests.Tests.Services
{
    [TestClass]
    public class CountyDataServiceTests
    {
        ICountryDataService countryDataService;

        [TestInitialize]
        public void Initialize()
        {
            countryDataService = ServiceMocks.GetMockCountryDataService(3);
        }

        [TestMethod]
        public async Task GetCountries_Return_AllCountries()
        {
            var countries = await countryDataService.GetAllCountries();

            Assert.AreEqual(3, countries.Count);
        }
    }
}