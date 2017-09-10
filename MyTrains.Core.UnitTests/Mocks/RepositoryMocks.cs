using System.Collections.Generic;
using Moq;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<ICityRepository> GetMockCityRepository(int count)
        {
            var list = new List<City>();
            var mockCityRepository = new Mock<ICityRepository>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new City { CityId = count });
            }

            mockCityRepository.Setup(m => m.GetAllCities()).ReturnsAsync(list);
            mockCityRepository.Setup(m => m.GetCityById(It.IsAny<int>())).ReturnsAsync(list[0]);
            return mockCityRepository;
        }

        public static Mock<IBeneficiaryRepository> GetMockBeneficiaryRepository(int count)
        {
            var list = new List<Beneficiary>();
            var mockBeneficiaryRepository = new Mock<IBeneficiaryRepository>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new Beneficiary { BeneficiaryId = count });
            }

            mockBeneficiaryRepository.Setup(m => m.GetAllBeneficiaries()).ReturnsAsync(list);
            mockBeneficiaryRepository.Setup(m => m.GetBeneficiaryById(It.IsAny<int>())).ReturnsAsync(list[0]);
            return mockBeneficiaryRepository;
        }
        public static Mock<ICountryRepository> GetMockCountryRepository(int count)
        {
            var list = new List<Country>();
            var mockCountryRepository = new Mock<ICountryRepository>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new Country { CountryId = count });
            }

            mockCountryRepository.Setup(m => m.GetAllCountries()).ReturnsAsync(list);
            mockCountryRepository.Setup(m => m.GetCountryById(It.IsAny<int>())).ReturnsAsync(list[0]);
            return mockCountryRepository;
        }
        public static Mock<IServiceRepository> GetMockServiceRepository(int count)
        {
            var list = new List<Service>();
            var mockServiceRepository = new Mock<IServiceRepository>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new Service { ServiceId = count });
            }

            mockServiceRepository.Setup(m => m.GetAllServices()).ReturnsAsync(list);
            mockServiceRepository.Setup(m => m.GetServiceById(It.IsAny<int>())).ReturnsAsync(list[0]);
            return mockServiceRepository;
        }
    }
}