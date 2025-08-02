using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;

namespace CMSCore.FileManagement
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

        public IEnumerable<FileSystemInfo> GenerateHostAsFiles(Host host)
        {
            _validator.Validate(host);

            return _generator.GenerateHostAsFiles(host);
        }
        public IDictionary<Host, IEnumerable<FileSystemInfo>> GenerateHostsAsFiles(IEnumerable<Host> hosts)
        {
            var validatedHostsAndConfigs = hosts.Select(t =>
            {
                _validator.Validate(t);

                return t;
            });

            return _generator.GenerateHostsAsFiles(hosts);
        }
    }
}
