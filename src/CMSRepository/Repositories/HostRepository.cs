using CMSRepository.Abstractions;
using CMSRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSRepository.Repositories
{
    public class HostRepository : BaseRepository<Host>, IHostRepository
    {
        public HostRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Host?> GetHostWithItsCreatorAsync(int id)
        {
            return await dbSet
                .AsNoTracking()
                .Include(h => h.Creator)
                .FirstOrDefaultAsync();
        }
    }
}