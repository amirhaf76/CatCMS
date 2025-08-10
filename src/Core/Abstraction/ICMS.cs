using CMSCore.Abstraction.Models;

namespace CMSCore.Abstraction
{
    public interface ICMS
    {
        
        IHostStorage Repository { get; }


        Host CreateAndAddHost();
        Page CreateAndAddPage(Guid hostId);


        IEnumerable<FileSystemInfo> GenerateHost(Guid hostId);
        Task<IEnumerable<FileSystemInfo>> GenerateHostAsync(Guid hostId);


        void UpdateHostConfig(Guid hostId, HostConfiguration hostConfig);
        Task UpdatePageContentAsync(PageUpdateDto arg);
    }
}
