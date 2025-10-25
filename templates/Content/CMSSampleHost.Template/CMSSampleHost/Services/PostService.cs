using CMSSampleHost.Models;

namespace CMSSampleHost.Services;

public class PostService
{
    private readonly List<Post> _posts;

    public PostService()
    {
        _posts = new List<Post>
        {
            new Post { Id = 1, Title = "Building a CMS with Bulma", Date = "Oct 23, 2025", Excerpt = "Learn how to design a modern CMS interface using Bulma and Razor Pages.", Content = "Full content for Building a CMS with Bulma...", ImageUrl = "https://picsum.photos/600/300?1" },
            new Post { Id = 2, Title = "Understanding Content Models", Date = "Oct 21, 2025", Excerpt = "Explore how structured content models make CMS data reusable and scalable.", Content = "Full content for Understanding Content Models...", ImageUrl = "https://picsum.photos/600/300?2" },
            new Post { Id = 3, Title = "Adding Authentication to Your CMS", Date = "Oct 19, 2025", Excerpt = "Implement secure login and signup features in your CMS.", Content = "Full content for Adding Authentication...", ImageUrl = "https://picsum.photos/600/300?3" },
            new Post { Id = 4, Title = "Building a CMS with Bulma 2", Date = "Oct 23, 2025", Excerpt = "Learn how to design a modern CMS interface using Bulma and Razor Pages.", Content = "Full content for Building a CMS with Bulma...", ImageUrl = "https://picsum.photos/600/300?1" },
            new Post { Id = 5, Title = "Understanding Content Models 2", Date = "Oct 21, 2025", Excerpt = "Explore how structured content models make CMS data reusable and scalable.", Content = "Full content for Understanding Content Models...", ImageUrl = "https://picsum.photos/600/300?2" },
        };
    }

    public IEnumerable<Post> GetAll() => _posts.OrderByDescending(p => p.Id);

    public Post? GetById(int id) => _posts.FirstOrDefault(p => p.Id == id);
}
