using CMSRepository.Models;
using Infrastructure.GenericRepository;

namespace CMSRepository.Abstractions
{
    public interface IHostRepository : IBaseRepository<Host>
    {
        Task<IEnumerable<Host>> GetHostsAsync(int theCreatorId, Pagination pagination);
        Task<Host?> GetHostAsync(int theCreatorId, Guid theHostId);
    }
}