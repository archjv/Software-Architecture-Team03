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

namespace AddressFinderWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //To store the search string from the search bar
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        ViewModel viewModel = new ViewModel();
        public static List<SelectListItem>? Options { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;                      
        }

        public void OnGet()
        {
            var name1 = Request.Query["f1name1"];
            var name2 = Request.Query["f2name1"];
            var name3 = Request.Query["f3name1"];
            var name4 = Request.Query["f4name1"];
            var name5 = Request.Query["f5name1"];

            if (name1 != "")
            {
                var address1 = Request.Query["f1address1"];
                var address2 = Request.Query["f1address2"];
                var province = Request.Query["f1province"];
                var city = Request.Query["f1city"];
                var zipcode = Request.Query["f1zipcode"];
            }
            else if (name2 != "")
            {
                var address1 = Request.Query["f2address1"];
                var address2 = Request.Query["f2address2"];
                var province = Request.Query["f2province"];
                var city = Request.Query["f2city"];
                var landmark = Request.Query["f2landmark"];
                var pincode = Request.Query["f2pincode"];
            }
            else if (name3 != "")
            {
                var address1 = Request.Query["f3address1"];
                var address2 = Request.Query["f3address2"];
                var province = Request.Query["f3province"];
                var city = Request.Query["f3city"];
                var pincode = Request.Query["f3postcode"];
            }
            else if (name4 != "")
            {
                var address1 = Request.Query["f4address1"];
                var streettypeandname = Request.Query["f4stsn"];
                var province = Request.Query["f4hno"];
                var city = Request.Query["f4nqs"];
                var zipcode = Request.Query["f4muncipality"];
                var landmark = Request.Query["f4postalcode"];
                var pincode = Request.Query["f4city"];
                var state = Request.Query["f4state"];
            }
            else if (name5 != "")
            {
                var address1 = Request.Query["f5address1"];
                var address2 = Request.Query["f5address2"];
                var province = Request.Query["f5province"];
                var city = Request.Query["f5city"];
                var zipcode = Request.Query["f5postalcode"];
            }
        }

        public void OnPost()
        {

        }
    }
}