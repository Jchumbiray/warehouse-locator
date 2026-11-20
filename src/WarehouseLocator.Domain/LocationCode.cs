using System.Text.RegularExpressions;

namespace WarehouseLocator.Domain
{
    public record LocationCode
    {
        private static readonly Regex Format = new(@"^[A-Z]-\d{2}-\d{2}$");

        public string Value { get; }

        public LocationCode(string value)
        {
            if (value is null || !Format.IsMatch(value))
            {
                throw new ArgumentException("Location code must look like A-01-03.");
            }

            Value = value;
        }




    }
}