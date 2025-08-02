using CMSCore.Abstraction.Models;

namespace CMSCore.Abstraction
{
    public interface IHostGenerator
    {
        IEnumerable<FileSystemInfo> GenerateHostAsFiles(Host host);
        IDictionary<Host, IEnumerable<FileSystemInfo>> GenerateHostsAsFiles(IEnumerable<Host> hosts);
    }
}
