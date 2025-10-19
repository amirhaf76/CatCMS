namespace CMS.Domain.ValueObjects
{
    public record PostId
    {
        private PostId(Guid id)
        {
            Value = id;
        }

        public static PostId Empty => new PostId(Guid.Empty);


        public static PostId Create(Guid id)
        {
            return new PostId(id);
        }


        public Guid Value { get; init; }
    }
}