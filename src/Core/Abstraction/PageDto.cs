namespace CMSCore.Abstraction
{
    public class PageDto
    {
        public Guid Id { get; set; } = Guid.Empty;

        public PageInfoDto PageInfo { get; set; } = new PageInfoDto();

    }

}