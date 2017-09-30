using SQLite;
using System;

namespace MyTrains.Core.Model
{
    [Table(nameof(Platform))]

    public class Platform : BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int PlatformId { get; set; }

        [NotNull, MaxLength(250)]

        public string PlatformName { get; set; }



        //public override string ToString()
        //{
        //    return $"{PlatformName} ({CurrencySymbol})";
        //}
        public bool IsValid()
        {
            return (!String.IsNullOrWhiteSpace(PlatformName));
        }
        public override string ToString()
        {
            return PlatformName;
        }
    }
}
