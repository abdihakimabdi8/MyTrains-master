using MyTrains.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrains.Core.Contracts.Services
{
    public interface IRecipientDataService
    {
        Task<List<Beneficiary>> GetAllRecipients();

        Task<Beneficiary> GetRecipientById(int recipientId);
        Task<Beneficiary> GetRecipientDetails(int recipientId);

    }
}
