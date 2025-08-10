using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;

namespace CMSCore
{
    public class HostFactory : IHostFactory
    {
        public Host CreateADefaultTemplate()
        {
            var host = new Host()
            {
                Title = "Default Host",
                Configuration = new HostConfiguration
                {
                    GeneratedCodesDirectory = Directory.GetCurrentDirectory(),
                }
            };

            return host;
        }
    }
}
