namespace CMS.Domain.ValueObjects
{
    public record PermissionId
    {
        public PermissionId(int id)
        {
            Value = id;
        }

        public static PermissionId Empty => new PermissionId(0);

        public static PermissionId Create(int id)
        {
            return new PermissionId(id);
        }


        public int Value { get; init; }
    }
}