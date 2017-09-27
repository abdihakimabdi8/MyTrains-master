using SQLite;
using System;

namespace MyTrains.Core.Models
{
    /// <summary>
    /// This class uses attributes that SQLite.Net can recognize
    /// and use to create the table schema.
    /// </summary>
    [Table(nameof(Transfer))]
    public class Transfer
    {
        [PrimaryKey, AutoIncrement]
        public int TransferId { get; set; }

        [NotNull]
        public string Recipient { get; set; }
        [NotNull, MaxLength(250)]
        public string Country { get; set; }

        [NotNull]
        public string City { get; set; }

        [NotNull]
        public string Service { get; set; }

        public Transfer()
        {
            Recipient = string.Empty;
            Country = string.Empty;
            City = string.Empty;
            Service = string.Empty;

        }

        public bool IsValid()
        {
            return (!String.IsNullOrWhiteSpace(Recipient) && !String.IsNullOrWhiteSpace(Country) && !String.IsNullOrWhiteSpace(City) && !String.IsNullOrWhiteSpace(Service));
        }
    }
}