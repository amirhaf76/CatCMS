using CMS.Domain.Entities;
using CMS.Domain.ValueObjects;
using SharedKernel;

namespace CMS.Domain.Repository
{
    public interface IHostRepository : IBaseRepository<Host>
    {
        Task<IEnumerable<Host>> GetHostsAsync(int theCreatorId, Pagination pagination);
        Task<IEnumerable<Host>> GetHostsAsync(UserId theCreatorId, Pagination pagination);
        Task<Host?> GetHostAsync(int theCreatorId, Guid theHostId);
        Task<Host?> GetHostAsync(UserId theCreatorId, Guid theHostId);
    }
}