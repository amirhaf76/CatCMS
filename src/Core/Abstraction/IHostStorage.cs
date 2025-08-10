using CMSCore.Abstraction.Models;

namespace CMSCore.Abstraction
{
    public interface IHostStorage
    {
        void AddHost(Host host);
        void AddHosts(IEnumerable<Host> hosts);


        Host GetHostById(Guid id);
        Host GetHostByIdOrDefault(Guid id);


        IEnumerable<Host> GetHosts();


        void RemoveHost(Guid hostId);
    }

}
