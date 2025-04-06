namespace CMSCore.Abstraction
{
    public interface ICMS
    {
        Host GetSiteByIdOrDefault(Guid id);
        Host GetSiteById(Guid id);

        IDictionary<Host, IEnumerable<FileInfo>> BuildHosts();
        IEnumerable<FileInfo> BuildHost(Guid hostId);

        void AddHost(Host host);
        void AddHosts(IEnumerable<Host> hosts);
    }
}
