using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;

namespace MyTrains.Core.Services.Data
{
    public class CountryDataService : ICountryDataService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryDataService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public virtual async Task<List<Country>> GetAllCountries()
        {
            return await _countryRepository.GetAllCountries();
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            return await _countryRepository.GetCountryById(countryId);
        }
    }
}