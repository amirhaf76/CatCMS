using CMSCore.Abstraction;

namespace CMSCore.FileManagement
{
    public interface IHostGenerator
    {
        IEnumerable<FileSystemInfo> GenerateHostAsFiles(Host host);
        IDictionary<Host, IEnumerable<FileSystemInfo>> GenerateHostsAsFiles(IEnumerable<Host> hosts);
    }
}
