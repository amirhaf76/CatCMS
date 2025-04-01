namespace CMSCore.Abstraction
{
    public interface ICMS
    {
        Host GetSiteByIdOrDefault(Guid id);
        Host GetSiteById(Guid id);

        IEnumerable<Host> BuildHosts();
        Host BuildHost(Guid hostId);

        void AddHost(Host s);
        void AddHosts(IEnumerable<Host> hosts);

    }
}
