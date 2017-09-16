using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;

namespace MyTrains.Core.Services.Data
{
    public class SavedBeneficiaryDataService : ISavedBeneficiaryDataService
    {
        private readonly ISavedBeneficiaryRepository _savedBeneficiaryRepository;
        //private readonly IRemittanceDataService _remittanceDataService;
       // private readonly ICityDataService _cityDataService;
        private readonly IBeneficiaryDataService _beneficiaryDataService;
       // private readonly ICountryDataService _countryDataService;
       // private readonly IServiceDataService _serviceDataService;


        public SavedBeneficiaryDataService(ISavedBeneficiaryRepository savedBeneficiaryRepository, IBeneficiaryDataService beneficiaryDataService)
        {
            _savedBeneficiaryRepository = savedBeneficiaryRepository;
            _beneficiaryDataService = beneficiaryDataService;

        }

        public async Task<IEnumerable<SavedBeneficiary>> GetSavedBeneficiaryForUser(int userId)
        {

            var list = await _savedBeneficiaryRepository.GetSavedBeneficiaryForUser(userId);
            foreach (var savedBeneficiary in list)
            {
                var beneficiary = await _beneficiaryDataService.GetBeneficiaryDetails(savedBeneficiary.BeneficiaryId);
                //beneficiary.BeneficiaryName = await _beneficiaryDataService.GetBeneficiaryById(BeneficiaryId);
                savedBeneficiary.Beneficiary = beneficiary;
                savedBeneficiary.BeneficiaryId = beneficiary.BeneficiaryId;
            }

            return list;
        }

        public async Task AddSavedBeneficiary(int userId, int beneficiaryId)
        {
            await _savedBeneficiaryRepository.AddSavedBeneficiary(userId, beneficiaryId);
        }
    }
}