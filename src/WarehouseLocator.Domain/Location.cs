namespace WarehouseLocator.Domain
{
    public class Location
    {
        public string Code { get;  }
        public int Capacity { get;  }

        public Location( string code, int capacity)
        {
            Code = code;
            Capacity = capacity;
        }


        public int Units { get; private set; }
        public void AddUnits (int quantity)
        {
            Units += quantity;
        }



        public LocationStatus Status
        {
            get
            {
                if (Units ==0)
                {
                    return LocationStatus.Available;
                }
                if (Units == Capacity)
                {
                    return LocationStatus.Full;
                }
                return LocationStatus.Partial; 
            }
        }

    }
}
