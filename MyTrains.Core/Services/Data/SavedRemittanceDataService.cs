using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;

namespace MyTrains.Core.Services.Data
{
    public class SavedRemittanceDataService : ISavedRemittanceDataService
    {
        private readonly ISavedRemittanceRepository _savedRemittanceRepository;
        private readonly IRemittanceDataService _remittanceDataService;
        private readonly ICityDataService _cityDataService;
        private readonly IBeneficiaryDataService _beneficiaryDataService;
        private readonly ICountryDataService _countryDataService;
        private readonly IServiceDataService _serviceDataService;


        public SavedRemittanceDataService(ISavedRemittanceRepository savedRemittanceRepository, IRemittanceDataService remittanceDataService, ICityDataService cityDataService, IBeneficiaryDataService beneficiaryDataService, ICountryDataService countryDataService, IServiceDataService serviceDataService)
        {
            _savedRemittanceRepository = savedRemittanceRepository;
            _remittanceDataService = remittanceDataService;
            _cityDataService = cityDataService;
            _beneficiaryDataService = beneficiaryDataService;
            _countryDataService = countryDataService;
            _serviceDataService = serviceDataService;

        }

        public async Task<IEnumerable<SavedRemittance>> GetSavedRemittanceForUser(int userId)
        {

            var list = await _savedRemittanceRepository.GetSavedRemittanceForUser(userId);
            foreach (var savedRemittance in list)
            {
                var remittance = await _remittanceDataService.GetRemittanceDetails(savedRemittance.RemittanceId);
                remittance.City = await _cityDataService.GetCityById(remittance.CityId);
                remittance.Beneficiary = await _beneficiaryDataService.GetBeneficiaryById(remittance.BeneficiaryId);
                remittance.Country = await _countryDataService.GetCountryById(remittance.CountryId);
                remittance.Service = await _serviceDataService.GetServiceById(remittance.ServiceId);



                savedRemittance.Remittance = remittance;
                savedRemittance.RemittanceId = remittance.RemittanceId;
            }

            return list;
        }

        public async Task AddSavedRemittance(int userId, int remittanceId, int beneficiaryId, int countryId, int cityId, int serviceId)
        {
            await _savedRemittanceRepository.AddSavedRemittance(userId, remittanceId, beneficiaryId,  countryId,  cityId,  serviceId);
        }
    }
}