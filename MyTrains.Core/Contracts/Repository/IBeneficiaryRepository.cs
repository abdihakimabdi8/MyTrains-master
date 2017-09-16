using MyTrains.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrains.Core.Contracts.Repository
{
    public interface IBeneficiaryRepository
    {
        Task<List<Beneficiary>> GetAllBeneficiaries();

        Task<Beneficiary> GetBeneficiaryById(int beneficiaryId);
        Task<Beneficiary> GetBeneficiaryDetails(int beneficiaryId);

    }
}
