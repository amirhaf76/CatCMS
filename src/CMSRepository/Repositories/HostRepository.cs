using CMSRepository.Abstractions;
using CMSRepository.Models;
using Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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



        public async Task<IEnumerable<Host>> GetHostsAsync(int theCreatorId, Pagination pagination)
        {
            pagination = ValidatePaginationAndAmendPageNumber(pagination);
            
            var skippedHostCount = (pagination.Number - 1) * pagination.Size;

            var query = dbSet
                .AsNoTracking()
                .Where(h => h.Creator.Id == theCreatorId)
                .Skip(skippedHostCount)
                .Take(pagination.Size);

            _logger?.LogDebug("Query string:\b {0}", query.ToQueryString());

            return await query.ToListAsync();
        }

        public async Task<Host?> GetHostAsync(int theCreatorId, Guid theHostId)
        {
            var host = new Host();

            return await dbSet
                .AsNoTracking()
                .Where(h => h.Id == theHostId && h.Creator.Id == theCreatorId)
                .FirstOrDefaultAsync();
        }

    }
}