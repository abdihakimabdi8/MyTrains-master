using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.UnitTests.Mocks;
using System.Threading.Tasks;

namespace MyTrains.Core.UnitTests.Tests.Repository
{
    [TestClass]
    public class BeneficiaryRepositoryTests
    {
        IBeneficiaryRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = RepositoryMocks.GetMockBeneficiaryRepository(3).Object;
        }

        [TestMethod]
        public async Task GetBeneficiaries_Return_All_Beneficiaries()
        {
            var beneficiaries = await repository.GetAllBeneficiaries();

            Assert.AreEqual(3, beneficiaries.Count);
        }
    }
}