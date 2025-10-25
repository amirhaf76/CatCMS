using CMS.Domain.ValueObjects;
using SharedKernel;

namespace CMS.Domain.Entities
{
    public class User : Entity
    {
        public int Id { get; set; }

        public Email Email { get; set; } = Email.Empty;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserStatus Status { get; set; }

        public ICollection<Host> Hosts { get; set; } = new HashSet<Host>();

        public ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();
    }
}
