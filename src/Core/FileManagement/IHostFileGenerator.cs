using CMSCore.Abstraction;

namespace CMSCore.FileManagement
{
    public interface IHostFileGenerator
    {
        IEnumerable<FileInfo> GenerateHostAsFiles(Host host, HostConfiguration hostConfig);
        IDictionary<Host, IEnumerable<FileInfo>> GenerateHostsAsFiles(IEnumerable<Tuple<Host, HostConfiguration>> hostsAndConfigs);
    }
}
