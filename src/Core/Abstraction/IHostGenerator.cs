using CMSCore.Abstraction.Models;

namespace CMSCore.Abstraction
{
    public interface IHostGenerator
    {
        string GeneratedFilesPath { get; set; }
        IEnumerable<FileSystemInfo> GenerateHostAsFiles(Host host);
        IDictionary<Host, IEnumerable<FileSystemInfo>> GenerateHostsAsFiles(IEnumerable<Host> hosts);
    }
}
