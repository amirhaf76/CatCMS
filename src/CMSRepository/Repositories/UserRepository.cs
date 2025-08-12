using CMSRepository.Abstractions;
using CMSRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSRepository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContexts) : base(dbContexts)
        {
        }

        public async Task<User?> FindUserWithItsHosts(int id)
        {
            return await dbSet
                .AsNoTracking()
                .Include(user => user.Hosts)
                .FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User?> GetUserAsync(string username)
        {
            return await dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username);
        }


    }
}