namespace MyTrains.Core.Model
{
    public class SavedRemittance : BaseModel
    {
        public int RemittanceId { get; set; }

        public Remittance Remittance { get; set; }

        public int UserId { get; set; }

        public int BeneficiaryId { get; set; }
        public int CountryId { get;  set; }
        public int CityId { get;  set; }
        public int ServiceId { get;  set; }
        public Beneficiary Beneficiary { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public Service Service { get; set; }
    }
}