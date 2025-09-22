using CMS.Domain.Entities;
using SharedKernel;

namespace CMS.Domain.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindUserWithItsHosts(int id);
        Task<User?> GetUserAsync(string username);
    }
}