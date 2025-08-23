using CMSApi.Abstraction.Services;
using CMSApi.Abstraction.Services.DTOs;
using CMSApi.Controllers.Extensions;
using CMSApi.Services.Exceptions;
using CMSCore.Abstraction;
using CMSRepository.Abstractions;
using CMSRepository.Models;
using System.Reflection;
using System.Security.Claims;

namespace CMSApi.Services
{
    public class CMSService : ICMSService
    {
        private readonly IHostRepository _hostRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostGenerator _hostGeneratorProvider;
        private readonly IConfiguration _configuration;



        public CMSService(
            IHostRepository hostRepository,
            IHttpContextAccessor httpContextAccessor,
            IHostGenerator hostGeneratorProvider,
            IConfiguration configuration)
        {
            _hostRepository = hostRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostGeneratorProvider = hostGeneratorProvider;
            _configuration = configuration;
        }



        public async Task<CMSRepository.Models.Host> AddHostAsync(string title)
        {

            int theCreatorId = GetUserIdFromHttpContext();

            var newHost = new CMSRepository.Models.Host()
            {
                Title = title,
                Creator = new CMSRepository.Models.User
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
            var theCreatorId = GetUserIdFromHttpContext();

            var theHosts = await _hostRepository.GetAsync(filter: host => host.Id == theHostId && host.Creator.Id == theCreatorId);

            var theHost = theHosts?.FirstOrDefault() ?? throw new HostNotFoundException();

            _hostRepository.Remove(theHost);

            await _hostRepository.SaveChangesAsync();
        }

        public async Task<CMSRepository.Models.Host> GetHostAsync(Guid theHostId)
        {
            var theCreatorId = GetUserIdFromHttpContext();

            var theHost = await _hostRepository.GetHostAsync(theCreatorId, theHostId);

            if (theHost == null)
            {
                throw new HostNotFoundException();
            }

            return theHost;
        }

        public async Task<IEnumerable<CMSRepository.Models.Host>> GetHostsAsync(PaginationDto pagination)
        {
            var theCreatorId = GetUserIdFromHttpContext();

            var theHosts = await _hostRepository.GetHostsAsync(theCreatorId, pagination.ToEntryFilter());

            return theHosts;
        }

        public async Task<IEnumerable<FileSystemInfo>> GenerateHostAsync(Guid theHostId)
        {
            var theCreatorId = GetUserIdFromHttpContext();

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
            
            var hostCMSCore = theHost.ToCoreModel();
            hostCMSCore.Configuration.GeneratedCodesDirectory = Path.Combine(GetProjectDirectory(), directory, $"host_{theHost.Title}_{theHost.Id}");
            var filesInformation = await _hostGeneratorProvider.GenerateHostAsFilesAsync(hostCMSCore);

            return filesInformation;
        }

        private string GetProjectDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        }

        public async Task PatchUpdateAsync(Guid hostId, IDictionary<string, object?> patch)
        {
            int theCreatorId = GetUserIdFromHttpContext();

            var hostEntity = new CMSRepository.Models.Host { Id = hostId };

            hostEntity.Creator.Id = theCreatorId;

            _hostRepository.ApplyPatch(hostEntity, patch);

            await _hostRepository.SaveChangesAsync();
        }



        private int GetUserIdFromHttpContext()
        {
            var id = GetClaimsPrincipalFromHttpContext()?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (int.TryParse(id, out int result))
            {
                return result;
            }

            throw new UserNotFoundException();
        }

        private ClaimsPrincipal? GetClaimsPrincipalFromHttpContext()
        {
            return _httpContextAccessor?.HttpContext?.User;
        }


    }
}
