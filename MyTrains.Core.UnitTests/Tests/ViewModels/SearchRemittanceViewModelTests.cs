using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Services.Data;
using MyTrains.Core.UnitTests.Mocks;
using MyTrains.Core.ViewModel;
using MyTrains.Core.Fake;

namespace MyTrains.Core.UnitTests.Tests.ViewModels
{
    [TestClass]
    public class SearchRemittanceViewModelTests
    {
        [TestMethod]
        public async Task Test_LoadFromCitiesCorrectly()
        {
            //arrange
            CityDataService mockCityDataService = ServiceMocks.GetMockCityDataService(3);
            var mockMessenger = new Mock<IMvxMessenger>();
            var mockConnectionService = new Mock<IConnectionService>();
            var mockDialogService = new Mock<IDialogService>();

            //act
            var searchRemittanceViewModel = new SearchRemittanceViewModel(mockMessenger.Object, mockCityDataService, mockConnectionService.Object, mockDialogService.Object );
            await searchRemittanceViewModel.LoadCities();

            //assert
            Assert.AreEqual(searchRemittanceViewModel.FromCities.Count, 3);
        }

        [TestMethod]
        public async Task Test_Initialize()
        {
            //arrange
            CityDataService mockCityDataService = ServiceMocks.GetMockCityDataService(3);
            var mockMessenger = new Mock<IMvxMessenger>();
            var mockConnectionService = new Mock<IConnectionService>();

            var a = mockConnectionService.Setup(m => m.CheckOnline()).Returns(true);

            var mockDialogService = new Mock<IDialogService>();
            
            //act
            var searchRemittanceViewModel = new FakeSearchRemittanceViewModel(mockMessenger.Object, mockCityDataService, mockConnectionService.Object, mockDialogService.Object);
            await searchRemittanceViewModel.InitializeAsync();

            //assert
            Assert.IsNotNull(searchRemittanceViewModel.FromCities);
            Assert.IsNotNull(searchRemittanceViewModel.ToCities);
            Assert.IsNotNull(searchRemittanceViewModel.SelectedFromCity);
            Assert.IsNotNull(searchRemittanceViewModel.SelectedToCity);
            Assert.IsNotNull(searchRemittanceViewModel.SelectedHour);
        }
    }
}
