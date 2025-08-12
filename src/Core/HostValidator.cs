using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;

namespace CMSCore
{
    public class HostValidator : IHostValidator
    {
        public void Validate(Host host)
        {


        }

        public void Validate(string path)
        {
            foreach (var invalidChar in Path.GetInvalidPathChars())
            {
                if (path.Contains(invalidChar))
                {
                    throw new InvalidPathCharException();
                }

            }
        }
    }

}
