using CMS.Domain.ValueObjects;
using SharedKernel;

namespace CMS.Domain.Entities
{
    public class Permission : Entity
    {

        private Permission(PermissionId id, string name)
        {
            Id = id;
            Name = name;
        }


        public static Permission Create(PermissionId id, string name)
        {
            return new Permission(id, name);
        }


        public PermissionId Id { get; init; }


        public string Name { get; private set; }
    }
}