using CMS.Domain.Entities;
using CMS.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CMS.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}