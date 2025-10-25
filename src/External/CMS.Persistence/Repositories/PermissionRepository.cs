using CMS.Domain.Entities;
using CMS.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CMS.Persistence.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}