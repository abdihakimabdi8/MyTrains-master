using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.Repositories
{
    public class SavedBeneficiaryRepository : BaseRepository, ISavedBeneficiaryRepository
    {

        private static readonly List<SavedBeneficiary> AllSavedBeneficiaries = new List<SavedBeneficiary>
        {
            new SavedBeneficiary {BeneficiaryId = 3, UserId = 1},
            new SavedBeneficiary {BeneficiaryId = 2, UserId = 1},
            new SavedBeneficiary {BeneficiaryId = 3, UserId = 1},
            new SavedBeneficiary {BeneficiaryId = 2, UserId = 1},
            new SavedBeneficiary {BeneficiaryId = 3, UserId = 2},
            new SavedBeneficiary {BeneficiaryId = 3, UserId = 2}
        };

        public async Task<IEnumerable<SavedBeneficiary>> GetSavedBeneficiaryForUser(int userId)
        {
            return await Task.FromResult(AllSavedBeneficiaries.Where(j => j.UserId == userId));
        }

        public async Task AddSavedBeneficiary(int userId, int beneficiaryId)
        {
            await
                Task.Run(
                    () =>
                        AllSavedBeneficiaries.Add(new SavedBeneficiary
                        {
                            BeneficiaryId = beneficiaryId,
                            UserId = userId
                        }));
        }

    }
}