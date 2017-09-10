using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.Repositories
{
    public class SavedRemittanceRepository : BaseRepository, ISavedRemittanceRepository
    {

        private static readonly List<SavedRemittance> AllSavedRemittances = new List<SavedRemittance>
        {
            new SavedRemittance {RemittanceId = 1, BeneficiaryId = 3, UserId = 1, CityId = 1, CountryId = 2, ServiceId = 1},
            new SavedRemittance {RemittanceId = 2, BeneficiaryId = 2, UserId = 1, CityId = 2, CountryId = 3, ServiceId = 1},
            new SavedRemittance {RemittanceId = 3, BeneficiaryId = 3, UserId = 1, CityId = 3, CountryId = 2, ServiceId = 1},
            new SavedRemittance {RemittanceId = 4, BeneficiaryId = 2, UserId = 1, CityId = 1, CountryId = 1, ServiceId = 1},
            new SavedRemittance {RemittanceId = 1, BeneficiaryId = 3, UserId = 2, CityId = 3, CountryId = 3, ServiceId = 1},
            new SavedRemittance {RemittanceId = 2, BeneficiaryId = 3, UserId = 2, CityId = 2, CountryId = 1, ServiceId = 1}
        };

        public async Task<IEnumerable<SavedRemittance>> GetSavedRemittanceForUser(int userId)
        {
            return await Task.FromResult(AllSavedRemittances.Where(j => j.UserId == userId));
        }

        public async Task AddSavedRemittance(int userId, int remittanceId, int beneficiaryId, int cityId, int countryId, int serviceId) 
        {
            await
                Task.Run(
                    () =>
                        AllSavedRemittances.Add(new SavedRemittance
                        {
                            RemittanceId = remittanceId,
                            BeneficiaryId = beneficiaryId,
                            CityId = cityId,
                            CountryId = cityId,
                            ServiceId = serviceId,
                            UserId = userId
                        }));
        }

    }
}