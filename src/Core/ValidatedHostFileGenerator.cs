using CMSCore.Abstraction;
using CMSCore.FileManagement;

namespace CMSCore
{
    public class ValidatedHostFileGenerator : IHostGenerator
    {
        private readonly IHostGenerator _generator;
        private readonly IHostValidator _validator;

        public ValidatedHostFileGenerator(IHostGenerator generator, IHostValidator validator)
        {
            _generator = generator;
            _validator = validator;
        }

        public IEnumerable<FileInfo> GenerateHostAsFiles(Host host, HostConfiguration hostConfig)
        {
            _validator.Validate(host);

            return _generator.GenerateHostAsFiles(host, hostConfig);
        }
        public IDictionary<Host, IEnumerable<FileInfo>> GenerateHostsAsFiles(IEnumerable<Tuple<Host, HostConfiguration>> hostsAndConfigs)
        {
            var validatedHostsAndConfigs = hostsAndConfigs.Select(t =>
            {
                _validator.Validate(t.Item1);

                return t;
            });

            return _generator.GenerateHostsAsFiles(validatedHostsAndConfigs);
        }
    }
}
