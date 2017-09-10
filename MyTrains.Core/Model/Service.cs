
namespace MyTrains.Core.Model
{
    public class Service : BaseModel
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public override string ToString()
        {
            return ServiceName;
        }
    }
}
