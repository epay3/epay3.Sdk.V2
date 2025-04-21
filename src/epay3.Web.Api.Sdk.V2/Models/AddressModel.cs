
namespace epay3.Web.Api.Sdk.V2.Models
{
    public class AddressModel
    {
        public string Suite { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public byte Country { get; set; }

        public string AddressWithoutSuite
        {
            get
            {
                return GetAddress(false);
            }
        }

        public string AddressWithSuite
        {
            get
            {
                return GetAddress(true);
            }
        }

        public string AddressWithSuiteAndCountry
        {
            get
            {
                return GetAddress(true);
            }
        }

        public string StreetAddress
        {
            get
            {
                var value = string.Empty;

                if (!string.IsNullOrEmpty(Street))
                    value += Street + " ";

                if (!string.IsNullOrEmpty(Suite))
                    if (int.TryParse(Suite.Trim(), out int number))
                        value += "#" + number + " ";
                    else
                        value += Suite + " ";

                return value;
            }
        }

        public string CountryName => ((Country)Country).GetDisplayName();

        private string GetAddress(bool showSuite)
        {
            var value = string.Empty;

            if (!string.IsNullOrEmpty(Street))
                value += Street + " ";

            if (showSuite && !string.IsNullOrEmpty(Suite))
                value += "#" + Suite + " ";

            if (!string.IsNullOrEmpty(City))
            {
                if (!string.IsNullOrEmpty(State))
                    value += City + ", ";
                else
                    value += City + " ";
            }

            if (!string.IsNullOrEmpty(State))
                value += State + " ";

            if (!string.IsNullOrEmpty(PostalCode))
                value += PostalCode + " ";

            if (!string.IsNullOrEmpty(CountryName))
            {
                value += CountryName;
            }

            return value.Trim();
        }
    }
}
