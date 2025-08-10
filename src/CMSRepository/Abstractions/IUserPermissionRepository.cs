using CMSRepository.Models;
using Infrastructure.GenericRepository;

namespace CMSRepository.Abstractions
{
    public interface IUserPermissionRepository : IBaseRepository<Permission>
    {
    }
}