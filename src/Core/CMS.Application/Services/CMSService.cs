using CMS.Application.Abstraction.Services;
using CMS.Application.Services.Exceptions;
using CMS.Domain.Entities;
using CMS.Domain.Repository;
using CMS.Domain.ValueObjects;
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
            UserId theCreatorId = _userProvider.UserIdV2;

            var newHost = Host.Create(theCreatorId, title);

            var createdHost = await _hostRepository.AddAsync(newHost);

            await _hostRepository.SaveChangesAsync();

            return createdHost;
        }


        public async Task RemoveHostAsync(Guid theHostId)
        {
            UserId theCreatorId = _userProvider.UserIdV2;

            var theHosts = await _hostRepository.GetAsync(filter: host => host.Id == theHostId && host.OwnerId == theCreatorId);

            var theHost = theHosts?.FirstOrDefault() ?? throw new HostNotFoundException();

            _hostRepository.Remove(theHost);

            await _hostRepository.SaveChangesAsync();
        }

        public async Task<Host> GetHostAsync(Guid theHostId)
        {
            UserId theCreatorId = _userProvider.UserIdV2;

            var theHost = await _hostRepository.GetHostAsync(theCreatorId, theHostId);

            if (theHost == null)
            {
                throw new HostNotFoundException();
            }

            return theHost;
        }

        public async Task<IEnumerable<Host>> GetHostsAsync(Pagination pagination)
        {
            UserId theCreatorId = _userProvider.UserIdV2;

            var theHosts = await _hostRepository.GetHostsAsync(theCreatorId, pagination);

            return theHosts;
        }

        public async Task<IEnumerable<FileSystemInfo>> GenerateHostAsync(Guid theHostId)
        {
            UserId theCreatorId = _userProvider.UserIdV2;

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
            UserId theCreatorId = _userProvider.UserIdV2;

            var theHost = Host.Create(HostId.Create(hostId), theCreatorId);

            _hostRepository.ApplyPatch(theHost, patch);

            await _hostRepository.SaveChangesAsync();
        }
    }

}
