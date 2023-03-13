using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AddressFinderWebApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting.Server;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Reflection.Emit;
using System.IO;
using System;

namespace AddressFinderWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //To store the search string from the search bar
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // Deserialize JSON to UserAddresses object
        UserAddresses userAddresses;

        public static UserAddresses results { get; set; }

        string jsonString;
        string path;
        public static List<SelectListItem>? Options { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            string trimmedPath = filePath.Substring(0, filePath.Length - @"bin\Debug\net6.0\".Length);
            path = Path.Combine(trimmedPath, "data.json");
            jsonString = System.IO.File.ReadAllText(path);//@"C:\Users\archa\source\repos\Software-Architecture-Team03\AddressFinderWebApplication\AddressFinderWebApplication\data.json");
            userAddresses = JsonConvert.DeserializeObject<UserAddresses>(jsonString);

            results = new UserAddresses();
            results.UserAddressesAustralia = new List<UserAddressAustralia>();
            results.UserAddressesCanada = new List<UserAddressCanada>();
            results.UserAddressesMexico = new List<UserAddressMexico>();
            results.UserAddressesUsa = new List<UserAddressUsa>();
            results.UserAddressesIndia = new List<UserAddressIndia>();
        }

        public void OnGet()
        {
            var name1 = Request.Query["f1name1"];
            var name2 = Request.Query["f2name1"];
            var name3 = Request.Query["f3name1"];
            var name4 = Request.Query["f4name1"];
            var name5 = Request.Query["f5name1"];

            if (name1.Count != 0)
            {
                // Modify the object by adding a new UserAddressUsa object to the UserAddressesUsa list
                var newAddress = new UserAddressUsa
                {
                    f1name1 = name1,
                    f1AddressLine2 = Request.Query["f1AddressLine2"],
                    f1city = Request.Query["f1city"],
                    f1zipcode = Request.Query["f1zipcode"],
                    State = Request.Query["state"],
                    f1AddressLine1 = Request.Query["f1AddressLine1"],
                };
                userAddresses.UserAddressesUsa.Add(newAddress);
            }

            else if (name2.Count != 0)
            {
                // Modify the object by adding a new UserAddressUsa object to the UserAddressesUsa list
                var newAddress = new UserAddressIndia
                {
                    AddressLine1 = Request.Query["f2AddressLine1"],
                    AddressLine2 = Request.Query["f2AddressLine2"],
                    District = Request.Query["district"],
                    City = Request.Query["f2city"],
                    Landmark = Request.Query["f2landmark"],
                    Pincode = Request.Query["f2pincode"],
                    State = Request.Query["state"],
                    Name = name2,
                };
                userAddresses.UserAddressesIndia.Add(newAddress);
            }
            else if (name3.Count != 0)
            {

                var newAddress = new UserAddressAustralia
                {
                    AddressLine1 = Request.Query["f3AddressLine1"],
                    AddressLine2 = Request.Query["f3AddressLine2"],
                    Province = Request.Query["f3province"],
                    City = Request.Query["f3city"],
                    Postcode = Request.Query["f3postcode"],
                    Name = name3,
                };
                userAddresses.UserAddressesAustralia.Add(newAddress);
            }
            else if (name4.Count != 0)
            {

                var newAddress = new UserAddressMexico
                {
                    StreetTypeAndName = Request.Query["f4stsn"],
                    HouseNumber = Request.Query["f4hno"],
                    NeighborhoodQuarterSettlement = Request.Query["f4nqs"],
                    Municipality = Request.Query["f4muncipality"],
                    PostalCode = Request.Query["f4postalcode"],
                    City = Request.Query["f4city"],
                    State = Request.Query["state"],
                    Name = name4,
                };
                userAddresses.UserAddressesMexico.Add(newAddress);
            }
            else if (name5.Count != 0)
            {
                var newAddress = new UserAddressCanada
                {
                    AddressLine1 = Request.Query["f5AddressLine1"],
                    AddressLine2 = Request.Query["f5AddressLine2"],
                    Province = Request.Query["f5province"],
                    City = Request.Query["f5city"],
                    PostalCode = Request.Query["f5postalcode"],
                    Name = name5,
                };
                userAddresses.UserAddressesCanada.Add(newAddress);
            }
            string json = JsonConvert.SerializeObject(userAddresses, Formatting.Indented);
            System.IO.File.WriteAllText(path, json);
        }

        public void SearchKeyword(UserAddresses userAddresses, string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();

                foreach (var address in userAddresses.UserAddressesCanada)
                {
                    if (address.Name.ToLower().Contains(keyword) || address.AddressLine1.ToLower().Contains(keyword) || address.AddressLine2.ToLower().Contains(keyword)
                        || address.Province.ToLower().Contains(keyword) || address.City.ToLower().Contains(keyword) || address.PostalCode.ToLower().Contains(keyword)
                        || address.Country.ToLower().Contains(keyword))
                    {
                        Console.WriteLine($"Address found in Canada: {address.Name}, {address.AddressLine1}, {address.City}, {address.Province}, {address.PostalCode}, {address.Country}");
                        var newAddress = new UserAddressCanada
                        {
                            Name = address.Name,
                            AddressLine1 = address.AddressLine1,
                            Province = address.Province,
                            City = address.City,
                            PostalCode = address.PostalCode,
                            Country = address.Country,

                        };
                        results.UserAddressesCanada.Add(newAddress);
                    }
                }

                foreach (var address in userAddresses.UserAddressesMexico)
                {
                    if (address.Name.ToLower().Contains(keyword) || address.StreetTypeAndName.ToLower().Contains(keyword) || address.HouseNumber.ToLower().Contains(keyword)
                        || address.NeighborhoodQuarterSettlement.ToLower().Contains(keyword) || address.Municipality.ToLower().Contains(keyword) || address.PostalCode.ToLower().Contains(keyword)
                        || address.City.ToLower().Contains(keyword) || address.State.ToLower().Contains(keyword) || address.Country.ToLower().Contains(keyword))
                    {
                        Console.WriteLine($"Address found in Mexico: {address.Name}, {address.StreetTypeAndName}, {address.HouseNumber}, {address.NeighborhoodQuarterSettlement}, {address.Municipality}, {address.PostalCode}, {address.City}, {address.State}, {address.Country}");

                        var newaddress = new UserAddressMexico
                        {
                            Name = address.Name,
                            StreetTypeAndName = address.StreetTypeAndName,
                            HouseNumber = address.HouseNumber,
                            City = address.City,
                            State = address.State,
                            Country = address.Country,
                            Municipality = address.Municipality,
                            NeighborhoodQuarterSettlement = address.NeighborhoodQuarterSettlement,
                            PostalCode = address.PostalCode,
                        };
                        results.UserAddressesMexico.Add(newaddress);
                    }
                }

                foreach (var address in userAddresses.UserAddressesAustralia)
                {
                    if (address.Name.ToLower().Contains(keyword) || address.AddressLine1.ToLower().Contains(keyword) || address.AddressLine2.ToLower().Contains(keyword)
                        || address.Province.ToLower().Contains(keyword) || address.City.ToLower().Contains(keyword) || address.Postcode.ToLower().Contains(keyword)
                        || address.Country.ToLower().Contains(keyword))
                    {
                        Console.WriteLine($"Address found in Australia: {address.Name}, {address.AddressLine1}, {address.AddressLine2}, {address.City}, {address.Province}, {address.Postcode}, {address.Country}");

                        var newaddress = new UserAddressAustralia
                        {
                            AddressLine1 = address.AddressLine1,
                            AddressLine2 = address.AddressLine2,
                            City = address.City,
                            Country = address.Country,
                            Name = address.Name,
                            Postcode = address.Postcode,
                            Province = address.Province,
                        };
                        results.UserAddressesAustralia.Add(newaddress);
                    }
                }

                foreach (var address in userAddresses.UserAddressesIndia)
                {
                    if (address.Name.ToLower().Contains(keyword) || address.AddressLine1.ToLower().Contains(keyword) || address.AddressLine2.ToLower().Contains(keyword)
                        || address.Landmark.ToLower().Contains(keyword) || address.City.ToLower().Contains(keyword) || address.District.ToLower().Contains(keyword)
                        || address.Pincode.ToLower().Contains(keyword) || address.State.ToLower().Contains(keyword) || address.Country.ToLower().Contains(keyword))
                    {
                        Console.WriteLine($"Address found in India: {address.Name}, {address.AddressLine1}, {address.AddressLine2}, {address.Landmark}, {address.City}, {address.District}, {address.Pincode}, {address.State}, {address.Country}");
                        var newaddress = new UserAddressIndia
                        {
                            Country = address.Country,
                            AddressLine1 = address.AddressLine1,
                            AddressLine2 = address.AddressLine2,
                            City = address.City,
                            District = address.District,
                            Pincode = address.Pincode,
                            Landmark = address.Landmark,
                            Name = address.Name,
                            State = address.State,
                        };
                        results.UserAddressesIndia.Add(newaddress);
                    }
                }

                foreach (var address in userAddresses.UserAddressesUsa)
                {
                    if (address.f1name1.ToLower().Contains(keyword) || address.f1AddressLine1.ToLower().Contains(keyword) || address.f1AddressLine2.ToLower().Contains(keyword)
                        || address.f1city.ToLower().Contains(keyword) || address.f1zipcode.ToLower().Contains(keyword) || address.State.ToLower().Contains(keyword)
                        || address.f1country.ToLower().Contains(keyword))
                    {
                        Console.WriteLine($"Address found in USA: {address.f1name1}, {address.f1AddressLine1}, {address.f1AddressLine2}, {address.f1city}, {address.State}, {address.f1zipcode}, {address.f1country}");

                        var newaddress = new UserAddressUsa
                        {
                            f1country = address.f1country,
                            f1AddressLine1 = address.f1AddressLine1,
                            f1AddressLine2 = address.f1AddressLine2,
                            f1city = address.f1city,
                            f1name1 = address.f1name1,
                            f1zipcode = address.f1zipcode,
                            State = address.State,
                        };
                        results.UserAddressesUsa.Add(newaddress);
                    }
                }
            }
        }
        public void OnPost()
        {
            SearchKeyword(userAddresses, SearchString);
        }
    }
}