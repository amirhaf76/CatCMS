namespace Infrastructure.DotNetCLI
{
    public class DotnetCli : BaseDotnetCli, IDotnetCli
    {
        public async Task CreateTemplateAsync(string templateName, string targetName, string locationOutput)
        {
            var commandAndArguments = $"{DotnetCliCommand.NEW} {templateName} -o \"{locationOutput}\"  -n {targetName}";

            var result = await RunDotnetCommandAsync(commandAndArguments);

            if (!string.IsNullOrWhiteSpace(result.Error))
            {
                throw new Exception($"there is problem for template creation !!, command \"{commandAndArguments}\" command \"{commandAndArguments}\" Error: \"{result.Error}\"");
            }
        }

        public async Task PublishAsync(string templateName, string locationOutput)
        {
            var commandAndArguments = $"{DotnetCliCommand.PUBLISH} {templateName} -o {locationOutput}";

            var result = await RunDotnetCommandAsync(commandAndArguments);

            if (!string.IsNullOrWhiteSpace(result.Error))
            {
                throw new Exception($"there is problem for publishing !!, command \"{commandAndArguments}\" Error: \"{result.Error}\"");
            }
        }

        public async Task InstallTemplateNugetAsync(string nugetName)
        {
            var commandAndArguments = $"{DotnetCliCommand.NEW} install {nugetName}";

            var result = await RunDotnetCommandAsync(commandAndArguments);

            if (!string.IsNullOrEmpty(result.Error))
            {
                throw new Exception($"there is problem for nuget installation!!, command \"{commandAndArguments}\" Error: \"{result.Error}\"");
            }
        }

        public async Task<bool> IsDotNetInstalledAsync(string version)
        {
            var commandAndArguments = $"{DotnetCliFlag.LIST_SDKS}";

            var result = await RunDotnetCommandAsync(commandAndArguments);

            if (!string.IsNullOrEmpty(result.Error))
            {
                throw new Exception($"there is problem for dotnet sdks!!, command \"{commandAndArguments}\" Error: \"{result.Error}\"");
            }

            return result.Output.Contains(version);
        }

        public async Task<bool> IsTemplateInstalledAsync(string templateName)
        {
            var commandAndArguments = $"{DotnetCliCommand.NEW_LIST} {templateName}";

            var result = await RunDotnetCommandAsync(commandAndArguments);

            if (!string.IsNullOrEmpty(result.Error))
            {
                throw new Exception($"there is problem for dotnet sdks!!, command \"{commandAndArguments}\" Error: \"{result.Error}\"");
            }

            return result.Output.Contains(templateName);
        }
    }
}
