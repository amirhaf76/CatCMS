using CMSRepository.Abstractions;
using CMSRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSRepository.Repositories
{
    public class UserPermissionRepository : BaseRepository<Permission>, IUserPermissionRepository
    {
        public UserPermissionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}