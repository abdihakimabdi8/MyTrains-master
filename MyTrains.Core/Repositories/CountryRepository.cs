using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.Repositories
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        private static readonly List<Country> AllCountries = new List<Country>
        {
            new Country
            {
                CountryId = 0,
                CountryName = "Select Country"
            },
            new Country
            {
                CountryId = 1,
                CountryName = "Somalia"
            },
            new Country
            {
                CountryId = 1,
                CountryName = "Ethiopia"
            },
            new Country
            {

                 CountryId = 1,
                 CountryName = "Kenya"
            },
             new Country
            {
                CountryId = 1,
                CountryName = "United Kingdom"
            },

             new Country
            {

                CountryId = 1,
                CountryName = "Uganda"
            },

             new Country
            {

                CountryId = 1,
                CountryName = "South Africa"
            },

        };

        public async Task<List<Country>> GetAllCountries()
        {
            return await Task.FromResult(AllCountries);
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            return await Task.FromResult(AllCountries.FirstOrDefault(c => c.CountryId == countryId));
        }
    }
}
