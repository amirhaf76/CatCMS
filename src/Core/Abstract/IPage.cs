namespace Core.Abstract
{
    public interface IPage
    {
        public string Title { get; set; }

        public Guid Id { get; }
    }
}