using CMSCore.Abstraction;

namespace CMSCore
{
    public class HostValidator : IHostValidator
    {
        public void Validate(Host host)
        {
            if (host.Title == null) throw new ValidationOfNullException();

            if (host.Configuration == null) throw new ValidationOfNullException();

            if (host.Pages == null) throw new ValidationOfNullException();

        }
    }

}
