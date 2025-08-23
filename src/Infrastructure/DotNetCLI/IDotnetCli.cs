

namespace Infrastructure.DotNetCLI
{
    public interface IDotnetCli
    {
        Task<bool> IsDotNetInstalledAsync(string version);

        Task<bool> IsTemplateInstalledAsync(string templateName);

        Task InstallTemplateNugetAsync(string nugetName);

        Task CreateTemplateAsync(string templateName, string targetName, string locationOutput);
    }
}
