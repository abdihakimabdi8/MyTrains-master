using System.Collections.Generic;
using Moq;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;
using MyTrains.Core.Services.Data;

namespace MyTrains.Core.UnitTests.Mocks
{
    public class ServiceMocks
    {
        public static CityDataService GetMockCityDataService(int count)
        {
            var list = new List<City>();

            var mockexpenseRepository = new Mock<ICityRepository>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new City { CityId = count });
            }
            mockexpenseRepository.Setup(m => m.GetAllCities()).ReturnsAsync(list);

            var cityDataService = new CityDataService(mockexpenseRepository.Object);
            return cityDataService;
        }
        public static BeneficiaryDataService GetMockBeneficiaryDataService(int count)
        {
            var list = new List<Beneficiary>();

            var mockexpenseRepository = new Mock<IBeneficiaryRepository>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new Beneficiary { BeneficiaryId = count });
            }
            mockexpenseRepository.Setup(m => m.GetAllBeneficiaries()).ReturnsAsync(list);

            var beneficiaryDataService = new BeneficiaryDataService(mockexpenseRepository.Object);
            return beneficiaryDataService;
        }
        public static CountryDataService GetMockCountryDataService(int count)
        {
            var list = new List<Country>();

            var mockexpenseRepository = new Mock<ICountryRepository>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new Country { CountryId = count });
            }
            mockexpenseRepository.Setup(m => m.GetAllCountries()).ReturnsAsync(list);

            var countryDataService = new CountryDataService(mockexpenseRepository.Object);
            return countryDataService;
        }

        public static ServiceDataService GetMockServiceDataService(int count)
        {
            var list = new List<Service>();

            var mockexpenseRepository = new Mock<IServiceRepository>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new Service { ServiceId = count });
            }
            mockexpenseRepository.Setup(m => m.GetAllServices()).ReturnsAsync(list);

            var serviceDataService = new ServiceDataService(mockexpenseRepository.Object);
            return serviceDataService;
        }
    }
}