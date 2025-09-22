using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleHost.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<string>? Names { get; set; }

        public void OnGet()
        {
            Names = ["First", "Second", "Third"];
        }
    }
}
