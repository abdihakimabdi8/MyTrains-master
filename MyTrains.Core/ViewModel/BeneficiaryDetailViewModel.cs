using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Model;
using MvvmCross.Platform.Platform;

namespace MyTrains.Core.ViewModel
{
    public class BeneficiaryDetailViewModel : BaseViewModel, IBeneficiaryDetailViewModel
    {

        private readonly IRemittanceDataService remittanceDataService;
        private readonly ISavedBeneficiaryDataService _savedBeneficiaryDataService;
        private readonly ISavedRemittanceDataService _savedRemittanceDataService;
        private readonly IDialogService _dialogService;
        private readonly IBeneficiaryDataService _beneficiaryDataService;
        private readonly ICityDataService _cityDataService;
        private readonly ICountryDataService _countryDataService;
        private readonly IServiceDataService _serviceDataService;
        private readonly IUserDataService _userDataService;
        private Beneficiary _selectedBeneficiary;
        private int _beneficiaryId;
        private int _cityId;
        private int _countryId;
        private int _serviceId;

        public MvxCommand AddToSavedBeneficiariesCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    await _savedBeneficiaryDataService.AddSavedBeneficiary
                    (_userDataService.GetActiveUser().UserId, SelectedBeneficiary.BeneficiaryId);

                    //Hardcoded text, better with resx translations
                    //await
                    //    _dialogService.ShowAlertAsync("This journey is now in your Saved Journeys!", "My Trains says...", "OK");

                    await
                        _dialogService.ShowAlertAsync
                        (TextSource.GetText("AddedToSavedBeneficiariesMessage"),
                         TextSource.GetText("AddedToSavedBeneficiariesTitle"),
                         TextSource.GetText("AddedToSavedBeneficiariesButton"));
                });
            }
        }

        public MvxCommand CloseCommand
        { get { return new MvxCommand(() => Close(this)); } }

        public Beneficiary SelectedBeneficiary
        {
            get { return _selectedBeneficiary; }
            set
            {
                _selectedBeneficiary = value;
                RaisePropertyChanged(() => SelectedBeneficiary);
            }
        }

        public int BeneficiaryId
        {
            get { return _beneficiaryId; }
            set
            {
                _beneficiaryId = value;
                RaisePropertyChanged(() => BeneficiaryId);
            }
        }
        public int CityId
        {
            get { return _cityId; }
            set
            {
                _cityId = value;
                RaisePropertyChanged(() => CityId);
            }
        }
        public int ServiceId
        {
            get { return _serviceId; }
            set
            {
                _serviceId = value;
                RaisePropertyChanged(() => ServiceId);
            }
        }
        public int CountryId
        {
            get { return _countryId; }
            set
            {
                _countryId = value;
                RaisePropertyChanged(() => CountryId);
            }
        }

        public BeneficiaryDetailViewModel(IMvxMessenger messenger,
            IBeneficiaryDataService beneficiaryDataService,
            ISavedBeneficiaryDataService savedBeneficiaryDataService,
            IDialogService dialogService,
            IUserDataService userDataService) : base(messenger)
        {
            _beneficiaryDataService = beneficiaryDataService;
            _savedBeneficiaryDataService = savedBeneficiaryDataService;
            _dialogService = dialogService;
            _userDataService = userDataService;
        }

        public void Init(int remittanceId)
        {
            _beneficiaryId = remittanceId;
        }

        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            SelectedBeneficiary = await _beneficiaryDataService.GetBeneficiaryDetails(_beneficiaryId);
        }

        public class SavedState
        {
            public int BeneficiaryId { get; set; }
        }

        public SavedState SaveState()
        {
            MvxTrace.Trace("SaveState called");
            return new SavedState { BeneficiaryId = _beneficiaryId };
        }

        public void ReloadState(SavedState savedState)
        {
            MvxTrace.Trace("ReloadState called with {0}",
                savedState.BeneficiaryId);
            _beneficiaryId = savedState.BeneficiaryId;
        }
    }
}