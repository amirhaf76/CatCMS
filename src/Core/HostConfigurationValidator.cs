using CMSCore.Abstraction;
using CMSCore.Exceptions;

namespace CMSCore
{
    public class HostConfigurationValidator : IHostConfigurationValidator
    {
        public void ValidatePath(string path)
        {
            if (Path.IsPathFullyQualified(path)) throw new UnqualifiedPathException();
        }

        public void ValidateDomainAddress(string domainAddress)
        {
            if (string.IsNullOrEmpty(domainAddress)) throw new Exception($"{nameof(domainAddress)} is null or incorrect.");
        }
    }


}