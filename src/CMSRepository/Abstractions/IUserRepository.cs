using CMSRepository.Models;

namespace CMSRepository.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindUserWithItsHosts(int id);
        Task<User?> GetUserAsync(string username);
    }
}