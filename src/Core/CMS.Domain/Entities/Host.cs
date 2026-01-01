using CMS.Domain.ValueObjects;
using SharedKernel;

namespace CMS.Domain.Entities
{
    public class Host : Entity
    {
        public Host()
        {

        }

        private Host(HostId hostId, UserId ownerId, string title)
        {

        }

        public static Host Create(HostId hostId, UserId ownerId, string title)
        {
            return new Host(hostId, ownerId, title);
        }
        public static Host Create(HostId hostId, UserId ownerId)
        {
            return new Host(hostId, ownerId, string.Empty);
        }
        public static Host Create(UserId ownerId, string title)
        {
            return new Host(HostId.Empty, ownerId, title);
        }

        public HostId HostId { get; init; }

        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public UserId OwnerId { get; private set; } = UserId.Empty;

        public User Owner { get; private set; } = User.Empty;

        public string GeneratedCodesDirectory { get; set; } = string.Empty;

        public string DomainAddress { get; set; } = string.Empty;


        public void UpdateOwner(User user)
        {
            OwnerId = user.UserId;
            Owner = user;
        }

        public void UpdateGeneratedCodesDirectory(string directoryPath)
        {
            GeneratedCodesDirectory = directoryPath;
        }
        
        public void UpdateTitle(string directoryPath)
        {
            GeneratedCodesDirectory = directoryPath;
        }

        public void UpdateDomainAddress(string address)
        {
            DomainAddress = address;
        }

    }
}
