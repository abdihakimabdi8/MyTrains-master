using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.UnitTests.Mocks;
using System.Threading.Tasks;

namespace MyTrains.Core.UnitTests.Tests.Repository
{
    [TestClass]
    public class CountryRepositoryTests
    {
        ICountryRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = RepositoryMocks.GetMockCountryRepository(3).Object;
        }

        [TestMethod]
        public async Task GetCountries_Return_All_Countries()
        {
            var countries = await repository.GetAllCountries();

            Assert.AreEqual(3, countries.Count);
        }
    }
}