using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;

namespace MyTrains.Core.Services.Data
{
    public class BeneficiaryDataService : IBeneficiaryDataService
    {
        private readonly IBeneficiaryRepository _beneficiaryRepository;
        public BeneficiaryDataService(IBeneficiaryRepository beneficiaryRepository)
        {
            _beneficiaryRepository = beneficiaryRepository;
        }

        public virtual async Task<List<Beneficiary>> GetAllBeneficiaries()
        {
            return await _beneficiaryRepository.GetAllBeneficiaries();
        }

        public async Task<Beneficiary> GetBeneficiaryById(int beneficiaryId)
        {
            return await _beneficiaryRepository.GetBeneficiaryById(beneficiaryId);
        }
      
        public async Task<Beneficiary> GetBeneficiaryDetails(int beneficiaryId)
        {
            return await _beneficiaryRepository.GetBeneficiaryDetails(beneficiaryId);
        }
    }
}