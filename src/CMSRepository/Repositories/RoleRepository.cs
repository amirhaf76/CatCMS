using CMSRepository.Abstractions;
using CMSRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSRepository.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}