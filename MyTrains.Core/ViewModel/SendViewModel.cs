using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyTrains.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using System.Collections.ObjectModel;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Extensions;
using MyTrains.Core.Model;
using MyTrains.Core.Model.App;

namespace MyTrains.Core.ViewModel
{
    public class SendViewModel : BaseViewModel, ISendRemittanceViewModel
    {
        public List<Recipient> AllRecipients { get; set; }
        private readonly ICityDataService _cityDataService;
        private readonly IBeneficiaryDataService _beneficiaryDataService;
        private readonly ICountryDataService _countryDataService;
        private readonly IServiceDataService _serviceDataService;
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private Beneficiary _selectedBeneficiary;
        private Recipient _selectedRecipient;
        private Country _selectedCountry;
        private City _selectedCity;
        private Service _selectedService;
        private ObservableCollection<Beneficiary> _beneficiaries;
        private ObservableCollection<Country> _countries;
        private ObservableCollection<City> _cities;
        private ObservableCollection<Service> _services;

        private ObservableCollection<string> _possibleTimes;
        private string _sendContentTitle;
        private string _sendContentBody;

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
        public Recipient SelectedRecipient
        {
            get { return _selectedRecipient; }
            set
            {
                if (_selectedRecipient != value)
                {
                    _selectedRecipient = value;
                    RaisePropertyChanged(() => SelectedRecipient);
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

        public string SendContentTitle
        {
            get { return _sendContentTitle; }
            set
            {
                _sendContentTitle = value;
                RaisePropertyChanged(() => SendContentTitle);
            }
        }
        public string SendContentBody
        {
            get { return _sendContentBody; }
            set
            {
                _sendContentBody = value;
                RaisePropertyChanged(() => SendContentBody);
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
        Send _send;


        public ICommand SaveSend
        {
            get
            {
                return new MvxCommand(() => {
                    //if (_s.IsValid())
                    //{
                        // Here we are simply waiting for the thread to complete.
                        // In a production app, this would be the opportunity to
                        // provide UI updates while the save thread completes.
                        Mvx.Resolve<SendRepository>().CreateSend(_send).Wait();
                        Close(this);
                    //}
                });
            }
        }
        public IMvxCommand SendCommand
        {
            get
            {
                return new MvxCommand(() =>
                    ShowViewModel<SearchResultViewModel>(new SendParameters
                    {
                        RecipientId = SelectedRecipient.RecipientId,
                        CountryId = SelectedCountry.CountryId,
                        CityId = SelectedCity.CityId,
                        ServiceId = SelectedService.ServiceId,
                        //RemittanceDate = SelectedDate
                    }));
            }
        }

        public SendViewModel(IMvxMessenger messenger,
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

        }
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
                await LoadCountries();
                await LoadServices();

                SelectedRecipient = AllRecipients[0];
                SelectedCountry = Countries[0];
                SelectedCity = Cities[0];
                SelectedService = Services[0];
                PossibleTimes = new ObservableCollection<string>();
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

        internal async Task LoadCountries()
        {
            Countries = (await _countryDataService.GetAllCountries()).ToObservableCollection();
        }
        internal async Task LoadServices()
        {
            Services = (await _serviceDataService.GetAllServices()).ToObservableCollection();
        }
       
        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        // This is another place that could be improved.
        // We are using the async capabilities built in to SQLite-Net,
        // but in this example, we simply wait for the thread to complete.
        public void Init()
        {
           
        }
        public void Init(Send send = null)
        {
            Task<List<Recipient>> result = Mvx.Resolve<RecipientRepository>().GetAllRecipients();
            result.Wait();
            AllRecipients = result.Result;

           string  sendContentTitle = Mvx.Resolve<RecipientRepository>().GetSendContentTitle().ToString();
           string sendContentBody = Mvx.Resolve<RecipientRepository>().GetSendContentBody().ToString();

            SendContentTitle = sendContentTitle;
            SendContentBody = sendContentBody;
            _send = send == null ? new Send() : send;
            RaiseAllPropertiesChanged();
        }
    }
}

  