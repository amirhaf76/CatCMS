namespace CMS.Domain.ValueObjects
{
    public record UserId
    {
        private UserId(int id)
        {
            Value = id;
        }

        public static UserId Empty => new UserId(default(int));

        public static UserId Create(int id)
        {
            return new UserId(id);
        }

        public int Value { get; init; }
    }
}
