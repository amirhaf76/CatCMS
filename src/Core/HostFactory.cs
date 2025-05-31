using CMSCore.Abstraction;

namespace CMSCore
{
    public class HostFactory : IHostFactory
    {
        public Host CreateADefaultTemplate()
        {
            var host = new Host
            {
                Id = Guid.NewGuid(),
                Title = "Default Template Host"
            };

            host.Configuration.GeneratedCodesDirectory = Directory.GetCurrentDirectory();

            return host;
        }
    }
}
