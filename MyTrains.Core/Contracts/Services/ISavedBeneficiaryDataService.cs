using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTrains.Core.Model;

namespace MyTrains.Core.Contracts.Services
{
    public interface ISavedBeneficiaryDataService
    {
        Task<IEnumerable<SavedBeneficiary>> GetSavedBeneficiaryForUser(int userId);

        Task AddSavedBeneficiary(int userId, int beneficiaryId);
    }
}