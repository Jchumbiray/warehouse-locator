namespace WarehouseLocator.Domain
{
    public class Location
    {
        public LocationCode Code { get;  }
        public int Capacity { get;  }

        // 1) Un campo que recuerde si está bloqueada (junto a Units)
        private bool _isBlocked;

        public Location( string code, int capacity)
        {
            Code = new LocationCode(code);
            Capacity = capacity;
        }


        public int Units { get; private set; }
        public void AddUnits (int quantity)
        {
            ValidateQuantity(quantity);
            if (_isBlocked)
            {
                throw new DomainException("Cannot add units to a blocked location.");
            }
            if (Units + quantity > Capacity)
            {
                throw new DomainException("Quantity exceeds location capacity.");
            }
            Units += quantity;
        }

        public void RemoveUnits(int quantity)
        {
            ValidateQuantity(quantity);
            if (quantity > Units)
            {
                throw new DomainException("Cannot remove more units than available.");
            }
            Units -= quantity;
        }




        public void MoveUnitsTo(Location destination, int quantity)
        {
            if (this == destination)
            {
                throw new DomainException("Origin and destination must be different locations.");
            }
            if (destination._isBlocked)
            {
                throw new DomainException("Destination location is blocked.");
            }
            if (destination.Units + quantity > destination.Capacity)
            {
                throw new DomainException("Destination location does not have enough space.");
            }
            RemoveUnits(quantity);
            destination.AddUnits(quantity);
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




        private static void ValidateQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
        }





    }

}
