using CMSCore.Abstraction.Models;

namespace CMSCore.Abstraction
{
    public interface IHostValidator
    {
        void Validate(Host host);

        void Validate(string path);
    }

}
