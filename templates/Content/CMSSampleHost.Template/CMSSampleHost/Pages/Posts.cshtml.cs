using CMSSampleHost.Models;
using CMSSampleHost.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class PostsModel : PageModel
{
    private readonly PostService _postService;
    public IEnumerable<Post> Posts { get; set; } = Enumerable.Empty<Post>();

    public PostsModel(PostService postService)
    {
        _postService = postService;
    }

    public void OnGet()
    {
        Posts = _postService.GetAll();
    }
}
