using CMS.Domain.ValueObjects;
using SharedKernel;

namespace CMS.Domain.Entities
{
    public class Host : Entity
    {
        public HostId HostId { get; init; } = HostId.Empty;

        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public UserId OwnerId { get; private set; } = UserId.Empty;

        public User Creator { get; set; } = new User();

        public string GeneratedCodesDirectory { get; set; } = string.Empty;

        public string DomainAddress { get; set; } = string.Empty;

    }
}
