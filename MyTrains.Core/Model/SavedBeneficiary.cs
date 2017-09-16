namespace MyTrains.Core.Model
{
    public class SavedBeneficiary : BaseModel
    {
        public int BeneficiaryId { get; set; }
        public Beneficiary Beneficiary { get; set; }

        public int UserId { get; set; }

    }
}