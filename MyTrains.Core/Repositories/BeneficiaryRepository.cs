using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.Repositories
{
    public class BeneficiaryRepository : BaseRepository, IBeneficiaryRepository
    {
        private static readonly List<Beneficiary> AllBeneficiaries = new List<Beneficiary>
        {
             new Beneficiary
            {
                BeneficiaryId = 0,
                BeneficiaryName = "Select Beneficiary"
            },
            new Beneficiary
            {
                BeneficiaryId = 1,
                BeneficiaryName = "Maamo Maryan"
            },
            new Beneficiary
            {
                BeneficiaryId = 1,
                BeneficiaryName = "Ayaan Muxumed"
            },
            new Beneficiary
            {

                BeneficiaryId = 1,
                BeneficiaryName = "Ina Gaaxnuug"
            },
             new Beneficiary
            {

                BeneficiaryId = 1,
                BeneficiaryName = "Cabdi Shaxaad"
            },

             new Beneficiary
            {

                BeneficiaryId = 1,
                BeneficiaryName = "Cali Dawarsade"
            },

             new Beneficiary
            {

                BeneficiaryId = 1,
                BeneficiaryName = "Badal Baahane"
            },
           
        };

        public async Task<List<Beneficiary>> GetAllBeneficiaries()
        {
            return await Task.FromResult(AllBeneficiaries);
        }

        public async Task<Beneficiary> GetBeneficiaryById(int beneficiaryId)
        {
            return await Task.FromResult(AllBeneficiaries.FirstOrDefault(c => c.BeneficiaryId == beneficiaryId));
        }
        public async Task<Beneficiary> GetBeneficiaryDetails(int beneficiaryId)
        {
            return await Task.FromResult(AllBeneficiaries.FirstOrDefault(c => c.BeneficiaryId == beneficiaryId));
        }
    }
}
