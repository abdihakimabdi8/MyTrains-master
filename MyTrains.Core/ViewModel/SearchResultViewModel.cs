using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Extensions;
using MyTrains.Core.Messages;
using MyTrains.Core.Model;
using MyTrains.Core.Model.App;

namespace MyTrains.Core.ViewModel
{
    public class SearchResultViewModel : BaseViewModel, ISendResultViewModel
    {
        private readonly IRemittanceDataService _remittanceDataService;
        private readonly ICityDataService _cityDataService;
        private readonly ICountryDataService _countryDataService;
        private readonly IBeneficiaryDataService _beneficiaryDataService;
        private readonly IServiceDataService _serviceDataService;


        private int _cityId;
        private int _beneficiaryId;
        private int _countryId;
        private int _serviceId;

        private DateTime _remittanceDate;
        private string _departureTime;

        private ObservableCollection<Remittance> _remittances;
        private ObservableCollection<City> _cities;
        private ObservableCollection<Beneficiary> _beneficiaries;
        private ObservableCollection<Country> _countries;
        private ObservableCollection<Service> _services;


        public ObservableCollection<Remittance> Remittances
        {
            get { return _remittances; }
            set
            {
                _remittances = value;
                RaisePropertyChanged(() => Remittances);
            }
        }
        public ObservableCollection<Beneficiary> Beneficiaries
        {
            get { return _beneficiaries; }
            set
            {
                _beneficiaries = value;
                RaisePropertyChanged(() => Beneficiaries);
            }
        }
        public ObservableCollection<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                RaisePropertyChanged(() => Countries);
            }
        }
        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }
        public ObservableCollection<Service> Services
        {
            get { return _services; }
            set
            {
                _services = value;
                RaisePropertyChanged(() => Services);
            }
        }

        public MvxCommand<Remittance> ShowRemittanceDetailsCommand
        {
            get
            {
                return new MvxCommand<Remittance>(selectedRemittance =>
                {
                    ShowViewModel<RemittanceDetailViewModel>
                    (new { remittanceId = selectedRemittance.RemittanceId });
                });
            }
        }

        public MvxCommand ReloadDataCommand
        {
            get
            {
                return new MvxCommand(async () =>  
                {
                    Remittances = (await _remittanceDataService.SendRemittance(_cityId, _countryId, _beneficiaryId, _serviceId, _remittanceDate, DateTime.Parse(_departureTime))).ToObservableCollection();
                });
            }
        }


        public SearchResultViewModel(IMvxMessenger messenger, IRemittanceDataService remittanceDataService) : base(messenger)
        {
            _remittanceDataService = remittanceDataService;

            InitializeMessenger();
        }

        private void InitializeMessenger()
        {
            Messenger.Subscribe<CurrencyChangedMessage>
                (async message => await ReloadDataAsync());
        }

        public override async void Start()
        {
            base.Start();

            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            Remittances = (await _remittanceDataService.SendRemittance(_cityId, _beneficiaryId, _countryId, _serviceId, _remittanceDate, DateTime.Parse(_departureTime))).ToObservableCollection();
        }



        public void Init(SendParameters parameters)
        {
            _cityId = parameters.CityId;
            _beneficiaryId = parameters.BeneficiaryId;
            _countryId = parameters.CountryId;
            _serviceId = parameters.ServiceId;
            _remittanceDate = parameters.RemittanceDate;
            _departureTime = parameters.DepartureTime;
        }
    }
}