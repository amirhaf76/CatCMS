using CMSCore.Abstraction;

namespace CMSCore
{
    public class CatCMS : ICMS
    {
        private readonly List<Host> _hosts = new List<Host>();
        private readonly ICMSValidator _validator;
        private readonly IHostGenerator _generator;


        public CatCMS(IHostGenerator generator, ICMSValidator validator)
        {
            _generator = generator;
            _validator = validator;
        }


        public void AddHost(Host s)
        {
            _validator.Validate(s);

            _hosts.Add(s);
        }

        public void AddHosts(IEnumerable<Host> hosts)
        {
            foreach (var host in hosts)
            {
                _validator.Validate(host);
            }

            _hosts.AddRange(hosts);
        }

        public Host BuildHost(Guid hostId)
        {
            var host = GetSiteById(hostId);

            return BuildHost(host);
        }

        public IEnumerable<Host> BuildHosts()
        {
            var hosts = new List<Host>();

            foreach (var host in _hosts)
            {
                hosts.Add(BuildHost(host));
            }

            return hosts;
        }

        public Host GetSiteById(Guid id)
        {
            var host = GetSiteByIdOrDefault(id);

            if (host.IsDefault())
            {
                throw new SiteNotFoundException();
            }

            return host;
        }

        public Host GetSiteByIdOrDefault(Guid id)
        {
            return _hosts.FirstOrDefault(theSite => theSite.Id == id) ?? new Host();
        }


        private Host BuildHost(Host host)
        {
            _generator.GenerateHostAsFiles(host);

            return host;
        }
    }
}
