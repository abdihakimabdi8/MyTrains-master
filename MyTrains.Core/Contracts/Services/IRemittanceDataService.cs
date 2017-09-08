using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTrains.Core.Model;
namespace MyTrains.Core.Contracts.Services
{
    public interface IRemittanceDataService
    {
        Task<IEnumerable<Remittance>> SearchRemittance(int fromCity, int toCity, DateTime remittanceDate, DateTime departureTime);

        Task<Remittance> GetRemittanceDetails(int remittanceId);
    }
}
