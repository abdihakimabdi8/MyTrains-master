using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;

namespace MyTrains.Core.Services.Data
{
    public class RemittanceDataService : IRemittanceDataService
    {
        private readonly IRemittanceRepository _remittanceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IBeneficiaryRepository _beneficiaryRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IServiceRepository _serviceRepository;

        public RemittanceDataService(IRemittanceRepository remittanceRepository,
            ICityRepository cityRepository, IBeneficiaryRepository beneficiaryRepository, ICountryRepository countryRepository, IServiceRepository serviceRepository)
        {
            _remittanceRepository = remittanceRepository;
            _cityRepository = cityRepository;
            _beneficiaryRepository = beneficiaryRepository;
            _countryRepository = countryRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Remittance>> SendRemittance(int beneficiary, int country, int city, int service, DateTime remittanceDate, DateTime departureTime)
        {
            var remittances = await _remittanceRepository.SendRemittance(beneficiary, country, city, service, remittanceDate, departureTime);
            foreach (var remittance in remittances)
            {
                remittance.Beneficiary = await _beneficiaryRepository.GetBeneficiaryById(remittance.BeneficiaryId);
                remittance.Country = await _countryRepository.GetCountryById(remittance.CountryId);
                remittance.City = await _cityRepository.GetCityById(remittance.CityId);
                remittance.Service = await _serviceRepository.GetServiceById(remittance.ServiceId);
            }
            return remittances;
        }

        public async Task<Remittance> GetRemittanceDetails(int remittanceId)
        {
            return await _remittanceRepository.GetRemittanceDetails(remittanceId);
        }
    }
}