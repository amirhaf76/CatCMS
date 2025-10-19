namespace CMS.Domain.ValueObjects
{
    public record RoleId
    {
        private RoleId(int id)
        {
            Value = id;
        }

        public static RoleId Empty => new RoleId(0);

        public static RoleId Create(int id)
        {
            return new RoleId(id);
        }


        public int Value { get; init; }


    }
}