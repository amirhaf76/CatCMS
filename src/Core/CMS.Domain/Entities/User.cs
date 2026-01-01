using CMS.Domain.ValueObjects;
using SharedKernel;

namespace CMS.Domain.Entities
{
    public class User : Entity
    {
        private User(UserId userId, Email email, string username, string password, UserStatus status)
        {
            UserId = userId;
            Email = email;
            Username = username;
            Password = password;
            Status = status;

        }



        public static User Create(UserId userId, Email email, string username, string password, UserStatus status)
        {
            return new User(
                userId,
                email,
                username,
                password,
                status);
        }

        public static User Empty => new(UserId.Empty, Email.Empty, string.Empty, string.Empty, UserStatus.NotActivate);



        public UserId UserId { get; private set; }

        public Email Email { get; private set; } = Email.Empty;

        public string Username { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public UserStatus Status { get; private set; }



        public ICollection<Host> Hosts { get; private set; } = new HashSet<Host>();

        public ICollection<Permission> Permissions { get; private set; } = new HashSet<Permission>();



        public void UpdatePassword(string password)
        {
            Password = password;
        }
    }
}
