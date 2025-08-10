using CMSRepository.Models;
using Infrastructure.GenericRepository;

namespace CMSRepository.Abstractions
{
    public interface IHostRepository : IBaseRepository<Host>
    {
        Task<IEnumerable<Host>> GetHostsWithItsCreatorAsync(int pageNum, int pageSiz);
        Task<Host?> GetHostWithItsCreatorAsync(int id);
    }
}