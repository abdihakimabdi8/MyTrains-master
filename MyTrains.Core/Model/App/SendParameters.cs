using System;

namespace MyTrains.Core.Model.App
{
    public class SendParameters
    {
        public int RecipientId { get; set; }
        public int BeneficiaryId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int ServiceId { get; set; }
        public DateTime RemittanceDate { get; set; }
        public string DepartureTime { get; set; }
    }
}