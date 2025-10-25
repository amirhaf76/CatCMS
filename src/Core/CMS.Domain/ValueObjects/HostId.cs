namespace CMS.Domain.ValueObjects
{
    public record HostId
    {
        private HostId(Guid id)
        {
            Value = id;
        }

        public static HostId Empty => new HostId(Guid.Empty);

        public static HostId Create(Guid id)
        {
            return new HostId(id);
        }

        public Guid Value { get; init; }
    }
}
