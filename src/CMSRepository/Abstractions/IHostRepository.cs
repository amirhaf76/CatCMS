using CMSRepository.Models;

namespace CMSRepository.Abstractions
{
    public interface IHostRepository : IBaseRepository<Host>
    {
        Task<Host?> GetHostWithItsCreatorAsync(int id);
    }
}