using CMSRepository.Models;
using Infrastructure.GenericRepository;

namespace CMSRepository.Abstractions
{
    public interface IHostRepository : IBaseRepository<Host>
    {
        Task<IEnumerable<Host>> GetHostsWithItsCreatorAsync(int theCreatorId, Pagination pagination);
        Task<Host?> GetHostWithItsCreatorAsync(int theCreatorId, Guid theHostId);
        Task<Host?> GetHostAsync(int theCreatorId, Guid theHostId);
    }
}