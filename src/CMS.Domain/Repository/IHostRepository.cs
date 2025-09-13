using CMS.Domain.Entities;
using SharedKernel;

namespace CMS.Domain.Repository
{
    public interface IHostRepository : IBaseRepository<Host>
    {
        Task<IEnumerable<Host>> GetHostsAsync(int theCreatorId, Pagination pagination);
        Task<Host?> GetHostAsync(int theCreatorId, Guid theHostId);
    }
}