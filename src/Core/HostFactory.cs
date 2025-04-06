using CMSCore.Abstraction;

namespace CMSCore
{
    public class HostFactory : IHostFactory
    {
        public Host CreateADefaultTemplate()
        {
            return new Host
            {
                Id = Guid.NewGuid(),
                Title = "Default Template Host",
            };
        }
    }
}
