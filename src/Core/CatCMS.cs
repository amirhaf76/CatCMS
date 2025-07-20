using CMSCore.Abstraction;
using CMSCore.FileManagement;

namespace CMSCore
{
    public class CatCMS : ICMS
    {

        private readonly IHostRepository _hosts;
        private readonly IHostGenerator _hostGenerator;
        private readonly IHostFactory _hostFactory;
        private readonly IPageFactory _pageFactory;



        public CatCMS(IHostRepository hosts, IHostGenerator generator, IHostFactory hostFactory, IPageFactory pageFactory)
        {
            _hosts = hosts;
            _hostGenerator = generator;
            _hostFactory = hostFactory;
            _pageFactory = pageFactory;
        }



        public void AddHost(Host host)
        {
            _hosts.AddHost(host);
        }

        public void AddHosts(IEnumerable<Host> hosts)
        {
            _hosts.AddHosts(hosts);
        }


        public HostDto CreateAndAddHost()
        {
            var aHost = _hostFactory.CreateADefaultTemplate();

            _hosts.AddHost(aHost);

            return aHost.ToDto();
        }

        public PageDto CreateAndAddPage(Guid hostId)
        {
            var theHost = _hosts.GetHostById(hostId);

            var aPage = _pageFactory.CreateADefaultTemplate();

            theHost.AddPage(aPage);

            return aPage.ToDto();
        }


        public void DeleteHost(Guid hostId)
        {
            _hosts.RemoveHost(hostId);
        }

        public void DeletePage(Guid pageId, Guid hostId)
        {
            var theHost = _hosts.GetHostById(hostId);

            theHost.Remove(pageId);
        }


        public IEnumerable<FileSystemInfo> GenerateHost(Guid hostId)
        {
            var theHost = _hosts.GetHostById(hostId);

            return _hostGenerator.GenerateHostAsFiles(theHost);
        }

        public Task<IEnumerable<FileSystemInfo>> GenerateHostAsync(Guid hostId)
        {
            throw new NotImplementedException(); 
        }


        public Host GetHostById(Guid id)
        {
            return _hosts.GetHostById(id);
        }

        public Host GetHostByIdOrDefault(Guid id)
        {
            return _hosts.GetHostByIdOrDefault(id);
        }


        public IEnumerable<Host> GetHosts()
        {
            return _hosts.GetHosts();
        }


        public void UpdateHostConfig(Guid hostId, HostConfiguration hostConfig)
        {
            throw new NotImplementedException();
        }


        public Task UpdatePageContentAsync(PageUpdateDto arg)
        {
            var theHost = _hosts.GetHostById(arg.HostId);

            var thePage = theHost.GetPageById(arg.PageId);

            if (thePage is null)
            {
                throw new PageNotFoundException();
            }

            // Todo: update content.

            return Task.CompletedTask;
        }



        private static HostConfiguration GetHostConfiguration(HostDto dto)
        {
            return dto.Configuration;
        }
    }
}
