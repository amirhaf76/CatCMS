using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ContactModel : PageModel
{
    [BindProperty] public string? Name { get; set; }
    [BindProperty] public string? Email { get; set; }
    [BindProperty] public string? Message { get; set; }
    public bool MessageSent { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        // In this prototype we simply mark the message as sent.
        MessageSent = true;
        // You could send email or store to DB here.
        return Page();
    }
}
