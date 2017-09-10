using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTrains.Core.Model;

namespace MyTrains.Core.Contracts.Repository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();

        Task<Country> GetCountryById(int countryId);
    }
}

