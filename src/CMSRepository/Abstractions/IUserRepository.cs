using CMSRepository.Models;
using Infrastructure.GenericRepository;

namespace CMSRepository.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindUserWithItsHosts(int id);
        Task<User?> GetUserAsync(string username);
    }
}