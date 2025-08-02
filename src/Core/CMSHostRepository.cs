using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;
using CMSCore.Exceptions;

namespace CMSCore
{
    public class CMSHostRepository : IHostRepository
    {
        private readonly List<Host> _hosts;

        public CMSHostRepository()
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

            if (GetHostId(host.ToDto()) == Guid.Empty)
            {
                throw new HostNotFoundException();
            }

            return host;
        }

        private static Guid GetHostId(HostDto host)
        {
            return host.Id;
        }

        public Host GetHostByIdOrDefault(Guid id)
        {
            return _hosts.FirstOrDefault(host => GetHostId(host.ToDto()) == id) ?? Host.Default;
        }

        public IEnumerable<Host> GetHosts()
        {
            return _hosts.AsReadOnly();
        }

        public void RemoveHost(Guid hostId)
        {
            var theHost = GetHostById(hostId);

            _hosts.Remove(theHost);
        }
    }

}
