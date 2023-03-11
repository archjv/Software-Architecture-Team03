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

        string json = "..."; // JSON string to deserialize

        // Deserialize JSON to UserAddresses object
        UserAddresses userAddresses;

        // Serialize UserAddresses object to JSON
        //string jsonOutput = JsonConvert.SerializeObject(userAddresses);

        string jsonString;

        public static List<SelectListItem>? Options { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            jsonString = System.IO.File.ReadAllText(@"C:\Users\archa\source\repos\Software-Architecture-Team03\AddressFinderWebApplication\AddressFinderWebApplication\data.json");
            userAddresses = JsonConvert.DeserializeObject<UserAddresses>(jsonString);
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
                var address1 = Request.Query["f1address1"];
                var address2 = Request.Query["f1address2"];
                var city = Request.Query["f1city"];
                var zipcode = Request.Query["f1zipcode"];
                // Modify the object by adding a new UserAddressUsa object to the UserAddressesUsa list
                var newAddress = new UserAddressUsa
                {
                    f1name1 = name1,
                    f1address2 = Request.Query["f1address2"],
                    f1city = Request.Query["f1city"],
                    f1zipcode = Request.Query["f1zipcode"],
                    State = Request.Query["f1state"],
                    f1address1 = Request.Query["f1address1"],
                };
                userAddresses.UserAddressesUsa.Add(newAddress);
            }

            else if (name2.Count != 0)
            {
                var address1 = Request.Query["f2address1"];
                var address2 = Request.Query["f2address2"];
                var province = Request.Query["f2province"];
                var city = Request.Query["f2city"];
                var landmark = Request.Query["f2landmark"];
                var pincode = Request.Query["f2pincode"];

                // Modify the object by adding a new UserAddressUsa object to the UserAddressesUsa list
                var newAddress = new UserAddressIndia
                {
                 Address1 = Request.Query["f2address1"],
                 Address2 = Request.Query["f2address2"],
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
                var address1 = Request.Query["f3address1"];
                var address2 = Request.Query["f3address2"];
                var province = Request.Query["f3province"];
                var city = Request.Query["f3city"];
                var pincode = Request.Query["f3postcode"];

                var newAddress = new UserAddressAustralia
                {
                    Address1 = Request.Query["f2address1"],
                    Address2 = Request.Query["f2address2"],
                    Province = Request.Query["f2province"],
                    City = Request.Query["f2city"],
                    Postcode = Request.Query["f3postcode"],
                    Name = name3,
                };
                userAddresses.UserAddressesAustralia.Add(newAddress);
            }
            else if (name4.Count != 0)
            {
                var address1 = Request.Query["f4address1"];
                var streettypeandname = Request.Query["f4stsn"];
                var province = Request.Query["f4hno"];
                var city = Request.Query["f4nqs"];
                var zipcode = Request.Query["f4muncipality"];
                var landmark = Request.Query["f4postalcode"];
                var pincode = Request.Query["f4city"];
                var state = Request.Query["f4state"];

                var newAddress = new UserAddressMexico
                {                    
                 StreetTypeAndName = Request.Query["f4stsn"],
                 HouseNumber = Request.Query["f4hno"],
                 NeighborhoodQuarterSettlement = Request.Query["f4nqs"],
                 Municipality = Request.Query["f4muncipality"],
                 PostalCode = Request.Query["f4postalcode"],
                 City = Request.Query["f4city"],
                 State = Request.Query["f4state"],
                 Name = name4,
            };
                userAddresses.UserAddressesMexico.Add(newAddress);
            }
            else if (name5.Count != 0)
            {
                var address1 = Request.Query["f5address1"];
                var address2 = Request.Query["f5address2"];
                var province = Request.Query["f5province"];
                var city = Request.Query["f5city"];
                var zipcode = Request.Query["f5postalcode"];

                var newAddress = new UserAddressCanada
                {
                    AddressLine1 = Request.Query["f5address1"],
                    AddressLine2 = Request.Query["f5address2"],
                    Province = Request.Query["f5province"],
                    City = Request.Query["f5city"],
                    PostalCode = Request.Query["f5postalcode"],
                    Name = name5,
                };
                userAddresses.UserAddressesCanada.Add(newAddress);
            }
            string json = JsonConvert.SerializeObject(userAddresses, Formatting.Indented);
            System.IO.File.WriteAllText(@"C:\Users\archa\source\repos\Software-Architecture-Team03\AddressFinderWebApplication\AddressFinderWebApplication\data.json", json);

        }

        public void OnPost()
            {

            }
        }
    }