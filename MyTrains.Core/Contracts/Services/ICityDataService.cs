using MyTrains.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrains.Core.Contracts.Services
{
   public interface ICityDataService
    {
        Task<List<City>> GetAllCities();

        Task<City> GetCityById(int cityId);
    }
}
