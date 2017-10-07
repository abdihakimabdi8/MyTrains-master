using MyTrains.Core.Model;
using SQLite;
using System;

namespace MyTrains.Core.Models
{
    /// <summary>
    /// This class uses attributes that SQLite.Net can recognize
    /// and use to create the table schema.
    /// </summary>
    [Table(nameof(Send))]
    public class Send
    {
        [PrimaryKey, AutoIncrement]
        public int SendId { get; set; }

        [Indexed]
        public int RecipientId { get; set; }

        [Indexed]
        public int CountryId { get; set; }

        [Indexed]
        public int CityId { get; set; }

        [Indexed]
        public int ServiceId { get; set; }

        //public Recipient Recipient { get; set; }
        //public Country Country { get; set; }
        //public City City { get; set; }
        //public Service Service { get; set; }

        //public Send()
        //{
        //    Recipient = string.Empty;
        //    Country = string.Empty;
        //    City = string.Empty;
        //    Service = string.Empty;

        //}

        //public bool IsValid()
        //{
        //    return (!String.IsNullOrWhiteSpace(Recipient) && !String.IsNullOrWhiteSpace(Country) && !String.IsNullOrWhiteSpace(City) && !String.IsNullOrWhiteSpace(Service));
       // }
    }
}