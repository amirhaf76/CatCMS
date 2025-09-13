using CMS.Domain.Entities;

namespace CMS.Application.Abstraction.Services
{
    public interface IHostGenerator
    {
        IEnumerable<FileSystemInfo> GenerateHostAsFiles(Host host);

        Task<IEnumerable<FileSystemInfo>> GenerateHostAsFilesAsync(Host host);

        IDictionary<Host, IEnumerable<FileSystemInfo>> GenerateHostsAsFiles(IEnumerable<Host> hosts);
    }
}
