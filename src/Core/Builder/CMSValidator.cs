using CMSCore.Abstraction;

namespace CMSCore.Builder
{
    public class CMSValidator : ICMSValidator
    {
        public Host Validate(Host host)
        {
            if (host == null) throw new ValidationOfNullException();

            return host;
        }
    }
}