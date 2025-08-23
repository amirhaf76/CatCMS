using CMSRepository.Models;
using CMSHelper.GenericRepository;

namespace CMSRepository.Abstractions
{
    public interface IUserPermissionRepository : IBaseRepository<Permission>
    {
    }
}