using CMSCore.Abstraction;
using CMSCore.FileManagement;

namespace CMSCore
{
    public class CatCMS : ICMS
    {

        private readonly IHostRepository _hosts;
        private readonly IHostFileGenerator _generator;


        public CatCMS(IHostRepository hosts, IHostFileGenerator generator)
        {
            _hosts = hosts;
            _generator = generator;
        }

        public void AddHost(Host host)
        {
            _hosts.AddHost(host);
        }
        public void AddHosts(IEnumerable<Host> hosts)
        {
            _hosts.AddHosts(hosts);
        }

        public IEnumerable<FileInfo> BuildHost(Guid hostId)
        {
            var host = _hosts.GetHostById(hostId);

            return _generator.GenerateHostAsFiles(host, host.Configuration);
        }
        public IDictionary<Host, IEnumerable<FileInfo>> BuildHosts()
        {
            var hostsAndConfigs = _hosts.GetHosts().Select(x => Tuple.Create(x, x.Configuration));

            return _generator.GenerateHostsAsFiles(hostsAndConfigs);
        }

        public Host GetSiteById(Guid id)
        {
            return _hosts.GetHostById(id);
        }
        public Host GetSiteByIdOrDefault(Guid id)
        {
            return _hosts.GetHostByIdOrDefault(id);
        }
    }

}
