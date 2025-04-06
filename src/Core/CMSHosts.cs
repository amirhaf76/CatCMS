using CMSCore.Abstraction;

namespace CMSCore
{
    public class CMSHosts : IHostRepository
    {
        private readonly List<Host> _hosts;

        public CMSHosts()
        {
            _hosts = new List<Host>();
        }

        public void AddHost(Host host)
        {
            _hosts.Add(host);
        }
        public void AddHosts(IEnumerable<Host> hosts)
        {
            _hosts.AddRange(hosts);
        }

        public Host GetHostById(Guid id)
        {
            var host = GetHostByIdOrDefault(id);

            if (host.IsDefault())
            {
                throw new HostNotFoundException();
            }

            return host;
        }
        public Host GetHostByIdOrDefault(Guid id)
        {
            return _hosts.FirstOrDefault(theSite => theSite.Id == id) ?? new Host();
        }

        public IEnumerable<Host> GetHosts()
        {
            return _hosts.AsReadOnly();
        }
    }

}
