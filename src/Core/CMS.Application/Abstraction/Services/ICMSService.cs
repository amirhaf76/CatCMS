using CMS.Domain.Entities;
using SharedKernel;

namespace CMS.Application.Abstraction.Services
{
    public interface ICMSService
    {
        Task RemoveHostAsync(Guid hostId);

        Task<IEnumerable<Host>> GetHostsAsync(Pagination pagination);

        Task<Host> AddHostAsync(string title);

        Task<Host> GetHostAsync(Guid theHostId);

        Task<IEnumerable<FileSystemInfo>> GenerateHostAsync(Guid id);

        Task PatchUpdateAsync(Guid hostId, IDictionary<string, object?> patch);

    }
}