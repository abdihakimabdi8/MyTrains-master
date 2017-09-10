using MyTrains.Core.ViewModel;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;

namespace MyTrains.Core.Fake
{
    public class FakeSendRemittanceViewModel : SendRemittanceViewModel
    {
        public FakeSendRemittanceViewModel(IMvxMessenger messenger, ICityDataService cityDataService, IConnectionService connectionService, IDialogService dialogService) : base(messenger, cityDataService, connectionService, dialogService)
        {
        }
        public FakeSendRemittanceViewModel(IMvxMessenger messenger, IBeneficiaryDataService beneficiaryDataService,  IConnectionService connectionService, IDialogService dialogService) : base(messenger, beneficiaryDataService, connectionService, dialogService)
        {
        }
        public FakeSendRemittanceViewModel(IMvxMessenger messenger, ICountryDataService countryDataService, IConnectionService connectionService, IDialogService dialogService) : base(messenger, countryDataService, connectionService, dialogService)
        {
        }
        public FakeSendRemittanceViewModel(IMvxMessenger messenger,  IServiceDataService serviceDataService, IConnectionService connectionService, IDialogService dialogService) : base(messenger, serviceDataService, connectionService, dialogService)
        {
        }
        public new Task InitializeAsync()
        {
            return base.InitializeAsync();
        }
    }
}
