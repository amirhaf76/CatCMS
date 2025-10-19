using CMS.Domain.Entities;
using CMS.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CMS.Persistence.Repositories
{
    public class UserPermissionRepository : BaseRepository<Permission>, IUserPermissionRepository
    {
        public UserPermissionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}