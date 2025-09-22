using CMS.Domain.Entities;

namespace CMS.Application.Abstraction.Services
{
    public interface IHostGenerator
    {
        Task<IEnumerable<FileSystemInfo>> GenerateHostAsFilesAsync(Host host);
    }
}
