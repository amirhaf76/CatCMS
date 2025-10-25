using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SignupModel : PageModel
{
    [BindProperty] public string? Name { get; set; }
    [BindProperty] public string? Email { get; set; }
    [BindProperty] public string? Password { get; set; }
    public bool Registered { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        // Mock registration: mark as registered
        Registered = true;
        return Page();
    }
}
