namespace CMSCore.Abstraction
{
    public interface IHostConfigurationValidator
    {
        void ValidatePath(string path);

        void ValidateDomainAddress(string domainAddress);

    }
}