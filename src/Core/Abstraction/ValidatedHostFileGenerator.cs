namespace CMSCore.Abstraction
{
    public class ValidatedHostFileGenerator : IHostFileGenerator
    {
        private readonly IHostFileGenerator _generator;
        private readonly IHostValidator _validator;

        public ValidatedHostFileGenerator(IHostFileGenerator generator, IHostValidator validator)
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
