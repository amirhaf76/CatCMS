using CMSApi.Abstraction.Services.DTOs;
using Infrastructure.GenericRepository;

namespace CMSApi.Abstraction.Services
{
    public interface ICMSService
    {
        Task RemoveHostAsync(Guid hostId);

        Task<IEnumerable<CMSRepository.Models.Host>> GetHostsAsync(PaginationDto pagination);

        Task<CMSRepository.Models.Host> AddHostAsync(string title);

        Task<CMSRepository.Models.Host> GetHostAsync(Guid theHostId);

        Task<IEnumerable<FileSystemInfo>> GenerateHostAsync(Guid id);

        Task PatchUpdateAsync(Guid hostId, IDictionary<string, object?> patch);

    }
}