namespace CMSCore.Abstraction.Models
{
    public static class CMSCoreExtension
    {

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