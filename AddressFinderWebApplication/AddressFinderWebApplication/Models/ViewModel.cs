using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;

namespace AddressFinderWebApplication.Models
{
    public class ViewModel
    {
        public List<SelectListItem> Options { get; set; }
    }


    public class UserAddressCanada
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; } = "CANADA";
    }

    public class UserAddressMexico
    {
        public string Name { get; set; }
        public string StreetTypeAndName { get; set; }
        public string HouseNumber { get; set; }
        public string NeighborhoodQuarterSettlement { get; set; }
        public string Municipality { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; } = "MEXICO";
    }


    public class UserAddressAustralia
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; } = "AUSTRALIA";
    }

    public class UserAddressIndia
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Country { get; set; } = "INDIA";
    }

    public class UserAddressUsa
    {
        public string f1name1 { get; set; }
        public string f1AddressLine1 { get; set; }
        public string f1AddressLine2 { get; set; }
        public string f1city { get; set; }
        public string f1zipcode { get; set; }
        public string State { get; set; }
        public string f1country { get; set; } = "USA";
    }

    public class UserAddresses
    {
        public List<UserAddressCanada> UserAddressesCanada { get; set; }

        public List<UserAddressMexico> UserAddressesMexico { get; set; }

        public List<UserAddressAustralia> UserAddressesAustralia { get; set; }

        public List<UserAddressIndia> UserAddressesIndia { get; set; }

        public List<UserAddressUsa> UserAddressesUsa { get; set; }
    }
}
