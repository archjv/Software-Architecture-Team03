using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AddressFinderWebApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AddressFinderWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        ViewModel viewModel = new ViewModel();
        public static List<SelectListItem>? Options { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;                      
        }



        public void OnGet()
        {

        }
    }
}