//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using MvvmCross.Plugins.Messenger;
//using MyTrains.Core.Contracts.Services;
//using MyTrains.Core.Services.Data;
//using MyTrains.Core.UnitTests.Mocks;
//using MyTrains.Core.ViewModel;
//using MyTrains.Core.Fake;

//namespace MyTrains.Core.UnitTests.Tests.ViewModels
//{
//    [TestClass]
//    public class SendRemittanceViewModelTests
//    {
//        [TestMethod]
//        public async Task Test_LoadCitiesCorrectly()
//        {
//            //arrange
//            CityDataService mockCityDataService = ServiceMocks.GetMockCityDataService(3);
//            var mockMessenger = new Mock<IMvxMessenger>();
//            var mockConnectionService = new Mock<IConnectionService>();
//            var mockDialogService = new Mock<IDialogService>();

//            //act
//            var sendRemittanceViewModel = new SendRemittanceViewModel(mockMessenger.Object, mockCityDataService, mockConnectionService.Object, mockDialogService.Object );
//            await sendRemittanceViewModel.LoadCities();

//            //assert
//            Assert.AreEqual(sendRemittanceViewModel.Cities.Count, 3);
//        }

//        [TestMethod]
//        public async Task Test_LoadBeneficiariesCorrectly()
//        {
//            //arrange
//            BeneficiaryDataService mockBeneficiaryDataService = ServiceMocks.GetMockBeneficiaryDataService(3);
//            var mockMessenger = new Mock<IMvxMessenger>();
//            var mockConnectionService = new Mock<IConnectionService>();
//            var mockDialogService = new Mock<IDialogService>();

//            //act
//            var sendRemittanceViewModel = new SendRemittanceViewModel(mockMessenger.Object, mockBeneficiaryDataService, mockConnectionService.Object, mockDialogService.Object);
//            await sendRemittanceViewModel.LoadBeneficiaries();
//            //assert
//            Assert.AreEqual(sendRemittanceViewModel.Beneficiaries.Count, 3);
//        }

//        [TestMethod]
//        public async Task Test_LoadCountriesCorrectly()
//        {
//            //arrange
//            CountryDataService mockCountryDataService = ServiceMocks.GetMockCountryDataService(3);
//            var mockMessenger = new Mock<IMvxMessenger>();
//            var mockConnectionService = new Mock<IConnectionService>();
//            var mockDialogService = new Mock<IDialogService>();

//            //act
//            var sendRemittanceViewModel = new SendRemittanceViewModel(mockMessenger.Object, mockCountryDataService, mockConnectionService.Object, mockDialogService.Object);
//            await sendRemittanceViewModel.LoadCountries();

//            //assert
//            Assert.AreEqual(sendRemittanceViewModel.Countries.Count, 3);
//        }

//        [TestMethod]
//        public async Task Test_LoadServicesCorrectly()
//        {
//            //arrange
//            ServiceDataService mockServiceDataService = ServiceMocks.GetMockServiceDataService(3);
//            var mockMessenger = new Mock<IMvxMessenger>();
//            var mockConnectionService = new Mock<IConnectionService>();
//            var mockDialogService = new Mock<IDialogService>();

//            //act
//            var sendRemittanceViewModel = new SendRemittanceViewModel(mockMessenger.Object, mockServiceDataService, mockConnectionService.Object, mockDialogService.Object);
//            await sendRemittanceViewModel.LoadServices();

//            //assert
//            Assert.AreEqual(sendRemittanceViewModel.Services.Count, 3);
//        }
//        [TestMethod]
//        public async Task Test_Initialize()
//        {
//            //arrange
//            CityDataService mockCityDataService = ServiceMocks.GetMockCityDataService(3);
//            BeneficiaryDataService mockBeneficiaryDataService = ServiceMocks.GetMockBeneficiaryDataService(3);
//            CountryDataService mockCountryDataService = ServiceMocks.GetMockCountryDataService(3);
//            ServiceDataService mockServiceDataService = ServiceMocks.GetMockServiceDataService(3);

//            var mockMessenger = new Mock<IMvxMessenger>();
//            var mockConnectionService = new Mock<IConnectionService>();

//            var a = mockConnectionService.Setup(m => m.CheckOnline()).Returns(true);

//            var mockDialogService = new Mock<IDialogService>();

//            //act
//            var sendRemittanceViewModel = new FakeSendRemittanceViewModel(mockMessenger.Object, mockCityDataService, mockConnectionService.Object, mockDialogService.Object);
//            await sendRemittanceViewModel.InitializeAsync();
//            NewMethod(mockBeneficiaryDataService, mockMessenger, mockConnectionService, mockDialogService);
//            await sendRemittanceViewModel.InitializeAsync();
//            NewMethod1(mockCountryDataService, mockMessenger, mockConnectionService, mockDialogService);
//            await sendRemittanceViewModel.InitializeAsync();
//            NewMethod2(mockServiceDataService, mockMessenger, mockConnectionService, mockDialogService);
//            await sendRemittanceViewModel.InitializeAsync();
//            //assert
//            Assert.IsNotNull(sendRemittanceViewModel.Cities);
//            Assert.IsNotNull(sendRemittanceViewModel.Beneficiaries);
//            Assert.IsNotNull(sendRemittanceViewModel.Countries);
//            Assert.IsNotNull(sendRemittanceViewModel.SelectedCity);
//            Assert.IsNotNull(sendRemittanceViewModel.SelectedBeneficiary);
//            Assert.IsNotNull(sendRemittanceViewModel.SelectedCountry);
//            Assert.IsNotNull(sendRemittanceViewModel.SelectedHour);
//        }

//        private static void NewMethod2(ServiceDataService mockServiceDataService, Mock<IMvxMessenger> mockMessenger, Mock<IConnectionService> mockConnectionService, Mock<IDialogService> mockDialogService)
//        {
//            var sendRemittanceViewModel = new FakeSendRemittanceViewModel(mockMessenger.Object, mockServiceDataService, mockConnectionService.Object, mockDialogService.Object);
//        }

//        private static void NewMethod1(CountryDataService mockCountryDataService, Mock<IMvxMessenger> mockMessenger, Mock<IConnectionService> mockConnectionService, Mock<IDialogService> mockDialogService)
//        {
//            var sendRemittanceViewModel = new FakeSendRemittanceViewModel(mockMessenger.Object, mockCountryDataService, mockConnectionService.Object, mockDialogService.Object);
//        }

//        private static void NewMethod(BeneficiaryDataService mockBeneficiaryDataService, Mock<IMvxMessenger> mockMessenger, Mock<IConnectionService> mockConnectionService, Mock<IDialogService> mockDialogService)
//        {
//            var sendRemittanceViewModel = new FakeSendRemittanceViewModel(mockMessenger.Object, mockBeneficiaryDataService, mockConnectionService.Object, mockDialogService.Object);
//        }

//    }
//}
