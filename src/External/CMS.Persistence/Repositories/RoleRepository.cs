using CMS.Domain.Entities;
using CMS.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CMS.Persistence.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}