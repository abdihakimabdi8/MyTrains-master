
namespace MyTrains.Core.Model
{
    public class Country : BaseModel
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public override string ToString()
        {
            return CountryName;
        }
    }
}
