using CMSApi.Abstraction.Services;
using CMSApi.Abstraction.Services.DTOs;
using CMSApi.Controllers.Extensions;
using CMSApi.Services.Exceptions;
using CMSCore.Abstraction;
using CMSRepository.Abstractions;
using Infrastructure.GenericRepository;
using System.Security.Claims;

namespace CMSApi.Services
{
    public class CMSService : ICMSService
    {
        private readonly IHostRepository _hostRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Func<string, IHostGenerator> _hostGeneratorProvider;



        public CMSService(
            IHostRepository hostRepository,
            IHttpContextAccessor httpContextAccessor,
            Func<string, IHostGenerator> hostGeneratorProvider)
        {
            _hostRepository = hostRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostGeneratorProvider = hostGeneratorProvider;
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

        public async Task<CMSRepository.Models.Host> GetHostWithItsCreatorAsync(Guid theHostId)
        {
            var theCreatorId = GetUserIdFromHttpContext();

            var theHost = await _hostRepository.GetHostWithItsCreatorAsync(theCreatorId, theHostId);

            if (theHost == null)
            {
                throw new HostNotFoundException();
            }

            return theHost;
        }

        public async Task<IEnumerable<CMSRepository.Models.Host>> GetHostsAsync(PaginationDto pagination)
        {
            var theCreatorId = GetUserIdFromHttpContext();

            var theHosts = await _hostRepository.GetHostsWithItsCreatorAsync(theCreatorId, pagination.ToEntryFilter());

            return theHosts;
        }

        public async Task<IEnumerable<CMSRepository.Models.Host>> GetHostsWithItsCreatorAsync(Pagination pagination)
        {
            var theCreatorId = GetUserIdFromHttpContext();

            var hosts = await _hostRepository.GetHostsWithItsCreatorAsync(theCreatorId, pagination);

            return hosts;
        }

        public async Task<IEnumerable<FileSystemInfo>> GenerateHostAsync(Guid theHostId)
        {
            var theCreatorId = GetUserIdFromHttpContext();

            var theHost = await _hostRepository.GetHostAsync(theCreatorId, theHostId);

            if (theHost == null)
            {
                throw new HostNotFoundException();
            }
            var hostCMSCore = theHost.ToCoreModel();

            // Todo: Use host configuration loaded from database.
            var generator = _hostGeneratorProvider.Invoke(".\\default\\");

            var filesInformation = generator.GenerateHostAsFiles(hostCMSCore);

            return filesInformation;
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
