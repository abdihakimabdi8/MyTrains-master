using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.Repositories
{
    public class RemittanceRepository : BaseRepository, IRemittanceRepository
    {

        private static readonly List<Remittance> AllRemittances = new List<Remittance>()
        {
            new Remittance
            {
                RemittanceId = 1,
                CityId = 1,
                BeneficiaryId  = 2,
                CountryId = 2,
                ServiceId = 1,
                DepartureTime = DateTime.Now.AddHours(1),
                ArrivalTime = DateTime.Now.AddHours(2),
                RemittanceDate = DateTime.Now,
                Platform = "12",
                Amount = 50
            },
            new Remittance
            {
                RemittanceId = 2,
                CityId = 2,
                BeneficiaryId = 1,
                CountryId = 1,
                ServiceId = 1,
                DepartureTime = DateTime.Now.AddHours(2),
                ArrivalTime = DateTime.Now.AddHours(3),
                RemittanceDate = DateTime.Now,
                Platform = "6",
                Amount = 100
            },
            new Remittance
            {
                RemittanceId = 3,
                CityId = 1,
                BeneficiaryId = 2,
                CountryId = 2,
                ServiceId = 1,
                DepartureTime = DateTime.Now.AddHours(4),
                ArrivalTime = DateTime.Now.AddHours(5),
                RemittanceDate = DateTime.Now,
                Platform = "6",
                Amount = 100
            },

            new Remittance
            {
                RemittanceId = 4,
                CityId = 1,
                BeneficiaryId = 2,
                CountryId = 3,
                ServiceId = 1,
                DepartureTime = DateTime.Now.AddHours(6),
                ArrivalTime = DateTime.Now.AddHours(7),
                RemittanceDate = DateTime.Now,
                Platform = "6",
                Amount = 100
            }
        };

        public async Task<IEnumerable<Remittance>> SendRemittance(int beneficiary, int country, int city, int service, DateTime remittanceDate, DateTime departureTime)
        {
            return await Task.FromResult(AllRemittances.Where(c => c.BeneficiaryId == beneficiary && c.CountryId == country)); //For demo purposes, the search doesn't mind the date and hour
        }

        public async Task<Remittance> GetRemittanceDetails(int remittanceId)
        {
            return await Task.FromResult(AllRemittances.FirstOrDefault(j => j.RemittanceId == remittanceId));
        }
    }
}