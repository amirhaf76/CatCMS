using CMSSampleHost.Models;
using CMSSampleHost.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly PostService _postService;
    public IEnumerable<Post> LatestPosts { get; set; } = Enumerable.Empty<Post>();

    public IndexModel(PostService postService)
    {
        _postService = postService;
    }

    public void OnGet()
    {
        LatestPosts = _postService.GetAll().Take(3);
    }
}
