
namespace MyTrains.Core.Model
{
    public class Beneficiary : BaseModel
    {
        public int BeneficiaryId { get; set; }

        public string BeneficiaryName { get; set; }

        public override string ToString()
        {
            return BeneficiaryName;
        }
    }
}
