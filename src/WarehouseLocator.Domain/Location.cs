namespace WarehouseLocator.Domain
{
    public class Location
    {
        public string Code { get;  }
        public int Capacacity { get;  }

        public Location( string code, int capacity)
        {
            Code = code;
            Capacacity = capacity;
        }

        public LocationStatus Status => LocationStatus.Available;
    }
}
