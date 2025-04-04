using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Registration.Web.Pages
{
    public class RegistrationSuccessModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string RegistrationId { get; set; }

        public void OnGet()
        {
        }
    }
}
