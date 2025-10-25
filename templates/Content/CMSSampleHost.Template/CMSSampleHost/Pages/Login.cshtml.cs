using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    [BindProperty] public string? Email { get; set; }
    [BindProperty] public string? Password { get; set; }
    public bool LoginFailed { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        // Mock authentication: accept any non-empty email/password
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            LoginFailed = true;
            return Page();
        }

        // In a real app you'd set auth cookie and redirect to admin area
        return RedirectToPage("/Admin/Index");
    }
}
