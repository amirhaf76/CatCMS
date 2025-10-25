using CMSSampleHost.Models;
using CMSSampleHost.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class PostModel : PageModel
{
    private readonly PostService _postService;
    public Post? Post { get; set; }

    public PostModel(PostService postService)
    {
        _postService = postService;
    }

    public void OnGet(int id)
    {
        Post = _postService.GetById(id);
    }
}
