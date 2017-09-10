using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTrains.Core.Model;

namespace MyTrains.Core.Contracts.Repository
{
    public interface ISavedRemittanceRepository
    {
        Task<IEnumerable<SavedRemittance>> GetSavedRemittanceForUser(int userId);

        Task AddSavedRemittance(int userId, int remittanceId, int beneficiaryId, int countryId, int cityId, int serviceId);
    }
}
