﻿namespace CMSCore.Abstraction
{
    public interface IHostRepository
    {
        void AddHost(Host host);
        void AddHosts(IEnumerable<Host> hosts);

        Host GetHostById(Guid id);
        Host GetHostByIdOrDefault(Guid id);

        IEnumerable<Host> GetHosts();

    }

}
