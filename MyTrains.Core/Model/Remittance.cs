using System;

namespace MyTrains.Core.Model
{
    public class Remittance : BaseModel
    {
        public int RemittanceId { get; set; }

        public int CityId { get; set; }

        public int CountryId { get; set; }

        public int BeneficiaryId { get; set; }

        public int ServiceId { get; set; }
        
        public City City { get; set; }

        public Country Country { get; set; }

        public Beneficiary Beneficiary { get; set; }

        public DateTime RemittanceDate { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public Service Service { get; set; }

        public double Amount { get; set; }

        public string Platform { get; set; }
    }
}