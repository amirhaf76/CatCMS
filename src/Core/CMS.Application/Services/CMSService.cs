using CMS.Application.Abstraction.Services;
using CMS.Application.Services.Exceptions;
using CMS.Domain.Entities;
using CMS.Domain.Repository;
using SharedKernel;
using System.Reflection;

namespace CMS.Application.Services
{
    public class CMSService : ICMSService
    {
        private readonly IHostRepository _hostRepository;
        private readonly IUserProvider _userProvider;
        private readonly IHostGenerator _hostGeneratorProvider;



        public CMSService(
            IHostRepository hostRepository,
            IHostGenerator hostGeneratorProvider,
            IUserProvider userProvider)
        {
            _hostRepository = hostRepository;
            _hostGeneratorProvider = hostGeneratorProvider;
            _userProvider = userProvider;
        }



        public async Task<Host> AddHostAsync(string title)
        {

            int theCreatorId = _userProvider.UserId;

            var newHost = new Host()
            {
                Title = title,
                Creator = new User
                {
                    Id = theCreatorId,
                },
            };

            var createdHost = await _hostRepository.AddAsync(newHost);

            await _hostRepository.SaveChangesAsync();

            return createdHost;
        }


        public async Task RemoveHostAsync(Guid theHostId)
        {
            var theCreatorId = _userProvider.UserId;

            var theHosts = await _hostRepository.GetAsync(filter: host => host.Id == theHostId && host.Creator.Id == theCreatorId);

            var theHost = theHosts?.FirstOrDefault() ?? throw new HostNotFoundException();

            _hostRepository.Remove(theHost);

            await _hostRepository.SaveChangesAsync();
        }

        public async Task<Host> GetHostAsync(Guid theHostId)
        {
            var theCreatorId = _userProvider.UserId;

            var theHost = await _hostRepository.GetHostAsync(theCreatorId, theHostId);

            if (theHost == null)
            {
                throw new HostNotFoundException();
            }

            return theHost;
        }

        public async Task<IEnumerable<Host>> GetHostsAsync(Pagination pagination)
        {
            var theCreatorId = _userProvider.UserId;

            var theHosts = await _hostRepository.GetHostsAsync(theCreatorId, pagination);

            return theHosts;
        }

        public async Task<IEnumerable<FileSystemInfo>> GenerateHostAsync(Guid theHostId)
        {
            var theCreatorId = _userProvider.UserId;

            var theHost = await _hostRepository.GetHostAsync(theCreatorId, theHostId);

            if (theHost == null)
            {
                throw new HostNotFoundException();
            }

            var directory = "Hosts";
            var projectFile = Path.Combine(GetProjectDirectory(), directory, $"host_{theHost.Title}_{theHost.Id}");

            if (Directory.Exists(projectFile))
            {
                throw new HostExistenceException();
            }

            var hostCMSCore = theHost;
            hostCMSCore.GeneratedCodesDirectory = Path.Combine(GetProjectDirectory(), directory, $"host_{theHost.Title}_{theHost.Id}");
            var filesInformation = await _hostGeneratorProvider.GenerateHostAsFilesAsync(hostCMSCore);

            return filesInformation;
        }

        private string GetProjectDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        }

        public async Task PatchUpdateAsync(Guid hostId, IDictionary<string, object?> patch)
        {
            int theCreatorId = _userProvider.UserId;

            var hostEntity = new Host { Id = hostId };

            hostEntity.Creator.Id = theCreatorId;

            _hostRepository.ApplyPatch(hostEntity, patch);

            await _hostRepository.SaveChangesAsync();
        }
    }

}
