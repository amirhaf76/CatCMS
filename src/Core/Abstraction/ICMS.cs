namespace CMSCore.Abstraction
{
    public interface ICMS
    {
        Host GetHostByIdOrDefault(Guid id);
        Host GetHostById(Guid id);

        IEnumerable<Host> GetHosts();


        void AddHost(Host host);
        void AddHosts(IEnumerable<Host> hosts);

        HostDto CreateAndAddHost();
        PageDto CreateAndAddPage(Guid hostId);

        IEnumerable<FileInfo> GenerateHost(Guid hostId);
        Task<IEnumerable<FileInfo>> GenerateHostAsync(Guid hostId);

        void DeleteHost(Guid hostId);
        void DeletePage(Guid pageId, Guid hostId);

        void UpdateHostConfig(Guid hostId, HostConfiguration hostConfig);
        Task UpdatePageContentAsync(PageUpdateDto arg);
    }
}
