using CMSRepository.Abstractions;
using CMSRepository.Models;
using Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CMSRepository.Repositories
{
    public class HostRepository : BaseRepository<Host>, IHostRepository
    {
        private readonly ILogger<HostRepository>? _logger;
        public HostRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public HostRepository(DbContext dbContext, ILogger<HostRepository>? logger) : base(dbContext)
        {
            _logger = logger;
        }



        public async Task<IEnumerable<Host>> GetHostsWithItsCreatorAsync(int theCreatorId, Pagination pagination)
        {
            pagination = ValidatePaginationAndAmendPageNumber(pagination);

            var skippedHostCount = (pagination.Number - 1) * pagination.Size;

            var query = dbSet
                .AsNoTracking()
                .Where(h => h.Creator.Id == theCreatorId)
                .OrderBy(h => h.Id)
                .Skip(skippedHostCount)
                .Take(pagination.Size)
                .Include(h => h.Configuration)
                .AsSplitQuery()
                .Include(h => h.Creator)
                .AsSplitQuery();

            _logger?.LogDebug("Query string:\b {0}", query.ToQueryString());

            return await query.ToListAsync();
        }

        public async Task<Host?> GetHostWithItsCreatorAsync(int theCreatorId, Guid theHostId)
        {
            return await dbSet
                .AsNoTracking()
                .Where(h => h.Id == theHostId && h.Creator.Id == theCreatorId)
                .Include(h => h.Creator)
                .FirstOrDefaultAsync();
        }

        public async Task<Host?> GetHostAsync(int theCreatorId, Guid theHostId)
        {
            return await dbSet
                .AsNoTracking()
                .Where(h => h.Id == theHostId && h.Creator.Id == theCreatorId)
                .FirstOrDefaultAsync();
        }
    }
}