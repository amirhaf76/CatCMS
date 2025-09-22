namespace CMS.Application.Abstraction.Services
{
    public interface IDotnetCli
    {
        Task<bool> IsDotNetInstalledAsync(string version);

        Task<bool> IsTemplateInstalledAsync(string templateName);

        Task InstallTemplateNugetAsync(string nugetName);

        Task CreateTemplateAsync(string templateName, string targetName, string locationOutput);

        Task PublishAsync(string templateName, string locationOutput);
    }
}
