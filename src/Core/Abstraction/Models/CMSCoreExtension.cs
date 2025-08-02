namespace CMSCore.Abstraction.Models
{
    public static class CMSCoreExtension
    {
        public static PageInfoDto Copy(this PageInfoDto dto)
        {
            return new PageInfoDto
            {
                Name = dto.Name,
                Path = dto.Path,
                Title = dto.Title,
            };
        }

        public static HostConfiguration Copy(this HostConfiguration dto)
        {
            return new HostConfiguration
            {
                DomainAddress = dto.DomainAddress,
                GeneratedCodesDirectory = dto.GeneratedCodesDirectory,
            };
        }
    }
}