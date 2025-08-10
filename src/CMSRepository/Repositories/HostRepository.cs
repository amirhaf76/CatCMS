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

        public async Task<IEnumerable<Host>> GetHostsWithItsCreatorAsync(int pageNum, int pageSiz)
        {
            pageNum = ValidatePaginationAndAmendPageNumber(pageNum, pageSiz);

            var skippedHostCount = (pageNum - 1) * pageSiz;

            return await dbSet
                .AsNoTracking()
                .Skip(skippedHostCount)
                .Take(pageSiz)
                .Include(h => h.Creator)
                .ToListAsync();
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