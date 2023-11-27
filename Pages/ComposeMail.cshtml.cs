using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class ComposeMailModel : PageModel
    {
        [BindProperty]
        public string Recipient { get; set; }

        [BindProperty]
        public string Subject { get; set; }

        [BindProperty]
        public string Body { get; set; }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {

                return RedirectToPage("/ComposeMail");
            }

            return Page();
        }
    }
}
