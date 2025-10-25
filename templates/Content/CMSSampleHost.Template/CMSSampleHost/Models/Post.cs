namespace CMSSampleHost.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Excerpt { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string Date { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
}
