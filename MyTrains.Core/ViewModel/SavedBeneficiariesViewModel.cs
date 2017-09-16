using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Extensions;
using MyTrains.Core.Messages;
using MyTrains.Core.Model;

namespace MyTrains.Core.ViewModel
{
    public class SavedBeneficiariesViewModel : BaseViewModel, ISavedBeneficiariesViewModel
    {
        private readonly ISavedBeneficiaryDataService _savedBeneficiaryDataService;
        private readonly IUserDataService _userDataService;

        private ObservableCollection<SavedBeneficiary> _savedBeneficiary;

        public MvxCommand ReloadDataCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var user = _userDataService.GetActiveUser();
                    SavedBeneficiaries = (await _savedBeneficiaryDataService.GetSavedBeneficiaryForUser(user.UserId)).ToObservableCollection();
                });
            }
        }

        public ObservableCollection<SavedBeneficiary> SavedBeneficiaries
        {
            get
            {
                return _savedBeneficiary;
            }
            set
            {
                _savedBeneficiary = value;
                RaisePropertyChanged(() => SavedBeneficiaries);
            }
        }
        // Remittance

        public SavedBeneficiariesViewModel(IMvxMessenger messenger, ISavedBeneficiaryDataService savedBeneficiaryDataService, IUserDataService userDataService) : base(messenger)
        {
            _savedBeneficiaryDataService = savedBeneficiaryDataService;
            _userDataService = userDataService;

            InitializeMessenger();
        }

        private void InitializeMessenger()
        {
            Messenger.Subscribe<CurrencyChangedMessage>(async message => await ReloadDataAsync());
        }


        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            var user = _userDataService.GetActiveUser();
            SavedBeneficiaries = (await _savedBeneficiaryDataService.GetSavedBeneficiaryForUser(user.UserId)).ToObservableCollection();
        }
    }
}