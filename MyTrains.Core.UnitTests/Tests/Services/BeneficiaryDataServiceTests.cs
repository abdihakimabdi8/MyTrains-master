using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.UnitTests.Mocks;
using System.Threading.Tasks;

namespace MyTrains.Core.UnitTests.Tests.Services
{
    [TestClass]
    public class BeneficiaryDataServiceTests
    {
        IBeneficiaryDataService beneficiaryDataService;

        [TestInitialize]
        public void Initialize()
        {
            beneficiaryDataService = ServiceMocks.GetMockBeneficiaryDataService(3);
        }

        [TestMethod]
        public async Task GetBeneficiaries_Return_All_Beneficiaries()
        {
            var beneficiaries = await beneficiaryDataService.GetAllBeneficiaries();

            Assert.AreEqual(3, beneficiaries.Count);
        }
    }
}