namespace WarehouseLocator.Domain
{
    public class Location
    {
        public string Code { get;  }
        public int Capacity { get;  }

        // 1) Un campo que recuerde si está bloqueada (junto a Units)
        private bool _isBlocked;

        public Location( string code, int capacity)
        {
            Code = code;
            Capacity = capacity;
        }


        public int Units { get; private set; }
        public void AddUnits (int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            if (_isBlocked)
            {
                throw new InvalidOperationException("Cannot add units to a blocked location.");
            }
            if (Units + quantity > Capacity)
{
                throw new InvalidOperationException("Quantity exceeds location capacity.");
            }
            Units += quantity;
        }

        public void RemoveUnits(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            if (quantity > Units)
{
                throw new InvalidOperationException("Cannot remove more units than available.");
            }
            Units -= quantity;
        }

        // 2) El método (junto a AddUnits)
        public void Block()
        {
            _isBlocked = true;
        }


        public LocationStatus Status
        {
            get
            {
                if (_isBlocked)
                {
                    return LocationStatus.Blocked;
                }
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
