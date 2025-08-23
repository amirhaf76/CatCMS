using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;
using CMSCore.Exceptions;

namespace CMSCore
{
    public class CMS : ICMS
    {

        private readonly IHostStorage _hosts;
        private readonly IHostGenerator _hostGenerator;
        private readonly IHostFactory _hostFactory;
        private readonly IPageFactory _pageFactory;

        public IHostStorage Repository => _hosts;

        public CMS(IHostStorage hosts, IHostGenerator generator, IHostFactory hostFactory, IPageFactory pageFactory)
        {
            _hosts = hosts;
            _hostGenerator = generator;
            _hostFactory = hostFactory;
            _pageFactory = pageFactory;
        }



        public Host CreateAndAddHost()
        {
            var aHost = _hostFactory.CreateADefaultTemplate();

            _hosts.AddHost(aHost);

            return aHost;
        }

        public Page CreateAndAddPage(Guid hostId)
        {
            var theHost = _hosts.GetHostById(hostId);

            var aPage = _pageFactory.CreateADefaultTemplate();

            theHost.Pages.Add(aPage);

            return aPage;
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


        public void UpdateHostConfig(Guid hostId, HostConfiguration hostConfig)
        {
            throw new NotImplementedException();
        }


        public Task UpdatePageContentAsync(PageUpdateDto arg)
        {
            var theHost = _hosts.GetHostById(arg.HostId);

            var thePage = theHost.Pages.FirstOrDefault(p => arg.PageId == p.Id);

            if (thePage is null)
            {
                throw new PageNotFoundException();
            }

            // Todo: update content.

            return Task.CompletedTask;
        }
    }
}
