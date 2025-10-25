using CMS.Domain.ValueObjects;
using SharedKernel;
using System.Drawing;

namespace CMS.Domain.Entities
{
    public class Role : Entity
    {
        private readonly HashSet<Permission> _permissions;

        private Role(RoleId id, string name)
        {
            Name = name;
            Id = id;
            _permissions = new HashSet<Permission>();
        }


        public static Role Create(RoleId id, string name)
        {
            return new Role(id, name);
        }


        public RoleId Id { get; private set; }

        public string Name { get; private set; }

        public ICollection<Permission> Permissions => _permissions.ToList();

    }
}