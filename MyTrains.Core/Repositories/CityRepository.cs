using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.Repositories
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        private static readonly List<City> AllCities = new List<City>
        {
            new City
            {
                CityId = 0,
                CityName = "Select City"
            },
            new City
            {
                CityId = 1,
                CityName = "Jig-Jiga"
            },
            new City
            {
                CityId = 2,
                CityName = "Hargeisa"
            },
            new City
            {
                CityId = 3,
                CityName = "Wajaale"
            },
             new City
            {
                CityId = 4,
                CityName = "Addis Ababa"
            },

             new City
            {
                CityId = 5,
                CityName = "Mogadishu"
            },

             new City
            {
                CityId = 6,
                CityName = "Bossaso"
            },
             new City
             {
                CityId = 7,
                CityName = "Nairobi"
            },
             new City
             {
                CityId = 8,
                CityName = "Dhagahbur"
            }
        };

        public async Task<List<City>> GetAllCities()
        {
            return await Task.FromResult(AllCities);
        }

        public async Task<City> GetCityById(int cityId)
        {
            return await Task.FromResult(AllCities.FirstOrDefault(c => c.CityId == cityId));
        }
    }
}
