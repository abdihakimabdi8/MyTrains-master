using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Extensions;
using MyTrains.Core.Model;
using MyTrains.Core.Model.App;

namespace MyTrains.Core.ViewModel
{
    //Remittance
    public class SendRemittanceViewModel : BaseViewModel, ISendRemittanceViewModel
    {
        private readonly ICityDataService _cityDataService;
        private readonly IBeneficiaryDataService _beneficiaryDataService;
        private readonly ICountryDataService _countryDataService;
        private readonly IServiceDataService _serviceDataService;
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private Beneficiary _selectedBeneficiary;
        private Country _selectedCountry;
        private City _selectedCity;
        private Service _selectedService;
        private ObservableCollection<Beneficiary> _beneficiaries;
        private ObservableCollection<Country> _countries;
        private ObservableCollection<City> _cities;
        private ObservableCollection<Service> _services;

        private ObservableCollection<string> _possibleTimes;
        private DateTime _selectedDate;
        private string _selectedHour;

        public Beneficiary SelectedBeneficiary
        {
            get { return _selectedBeneficiary; }
            set
            {
                if (_selectedBeneficiary != value)
                {
                    _selectedBeneficiary = value;
                    RaisePropertyChanged(() => SelectedBeneficiary);
                }
            }
        }

        public Service SelectedService
        {
            get { return _selectedService; }
            set
            {
                if (_selectedService != value)
                {
                    _selectedService = value;
                    RaisePropertyChanged(() => SelectedService);
                }
            }
        }
        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    RaisePropertyChanged(() => SelectedCountry);
                }
            }
        }
        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    RaisePropertyChanged(() => SelectedCity);
                }
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
        public ObservableCollection<Service> Services
        {
            get { return _services; }
            set
            {
                _services = value;
                RaisePropertyChanged(() => Services);
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
        public ObservableCollection<string> PossibleTimes
        {
            get { return _possibleTimes; }
            set
            {
                _possibleTimes = value;
                RaisePropertyChanged(() => PossibleTimes);
            }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                RaisePropertyChanged(() => SelectedDate);
            }
        }

        public string SelectedHour
        {
            get { return _selectedHour; }
            set
            {
                if (value != _selectedHour)
                {
                    _selectedHour = value;

                    RaisePropertyChanged(() => SelectedHour);
                }
            }
        }

        public IMvxCommand SendCommand
        {
            get
            {
                return new MvxCommand(() =>
                    ShowViewModel<SearchResultViewModel>(new SendParameters
                    {
                        DepartureTime = SelectedHour,
                        BeneficiaryId = SelectedBeneficiary.BeneficiaryId,
                        CountryId = SelectedCountry.CountryId,
                        CityId = SelectedCity.CityId,
                        ServiceId = SelectedService.ServiceId,
                        RemittanceDate = SelectedDate
                    }));
            }
        }

        public SendRemittanceViewModel(IMvxMessenger messenger,
            IBeneficiaryDataService beneficiaryDataService,
            ICountryDataService countryDatasService,
            IServiceDataService serviceDatasService,

            ICityDataService cityDataService,
            IConnectionService connectionService,
            IDialogService dialogService) : base(messenger)
        {
            _beneficiaryDataService = beneficiaryDataService;
            _countryDataService = countryDatasService;
            _serviceDataService = serviceDatasService;

            _cityDataService = cityDataService;
            _connectionService = connectionService;
            _dialogService = dialogService;

            SelectedDate = DateTime.Today;
        }
        //public SendRemittanceViewModel(IMvxMessenger messenger,
        //    IBeneficiaryDataService beneficiaryDataService,
        //    IConnectionService connectionService,
        //    IDialogService dialogService) : base(messenger)
        //{
        //    _beneficiaryDataService = beneficiaryDataService;
        //    _connectionService = connectionService;
        //    _dialogService = dialogService;

        //    SelectedDate = DateTime.Today;
        //}
        //public SendRemittanceViewModel(IMvxMessenger messenger,
        //    ICountryDataService countryDatasService,
        //    IConnectionService connectionService,
        //    IDialogService dialogService) : base(messenger)
        //{
        //    _countryDataService = countryDatasService;
        //    _connectionService = connectionService;
        //    _dialogService = dialogService;

        //    SelectedDate = DateTime.Today;
        //}
        //public SendRemittanceViewModel(IMvxMessenger messenger,
        //   IServiceDataService serviceDatasService,
        //   IConnectionService connectionService,
        //   IDialogService dialogService) : base(messenger)
        //{
        //    _serviceDataService = serviceDatasService;
        //    _connectionService = connectionService;
        //    _dialogService = dialogService;

        //    SelectedDate = DateTime.Today;
        //}
        public override async void Start()
        {
            base.Start();

            await ReloadDataAsync();
        }


        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            if (_connectionService.CheckOnline())
            {
                await LoadCities();
                await LoadBeneficiaries();
                await LoadCountries();
                await LoadServices();

                SelectedBeneficiary = Beneficiaries[0];
                SelectedCountry = Countries[0];
                SelectedCity = Cities[0];
                SelectedService = Services[0];
                PossibleTimes = new ObservableCollection<string>();
                GetDepartureTimes();

                SelectedHour = PossibleTimes[0];
            }
            else
            {
                await _dialogService.ShowAlertAsync("No internet available", "My Trains says...", "OK");
                //maybe we can navigate to a start page here, for you to add to this code base!
            }
        }

        internal async Task LoadCities()
        {
            Cities = (await _cityDataService.GetAllCities()).ToObservableCollection();
        }

        internal async Task LoadBeneficiaries()
        {
            Beneficiaries = (await _beneficiaryDataService.GetAllBeneficiaries()).ToObservableCollection();
        }

        internal async Task LoadCountries()
        {
            Countries = (await _countryDataService.GetAllCountries()).ToObservableCollection();
        }
        internal async Task LoadServices()
        {
            Services = (await _serviceDataService.GetAllServices()).ToObservableCollection();
        }
        private void GetDepartureTimes()
        {
            PossibleTimes.Add("9:00 am");
            PossibleTimes.Add("9:15 am");
            PossibleTimes.Add("9:30 am");
            PossibleTimes.Add("9:45 am");
            PossibleTimes.Add("10:00 am");
            PossibleTimes.Add("10:15 am");
            PossibleTimes.Add("10:30 am");
            PossibleTimes.Add("10:45 am");
            PossibleTimes.Add("11:00 am");
            PossibleTimes.Add("11:15 am");
            PossibleTimes.Add("12:30 am");
            PossibleTimes.Add("12:45 am");
        }
    }
}