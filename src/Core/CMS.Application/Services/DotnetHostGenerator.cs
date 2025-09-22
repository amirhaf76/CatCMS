using CMS.Application.Abstraction.Services;
using CMS.Application.Services;
using CMS.Domain.Entities;


namespace CMSCore.FileManagement
{
    public class DotnetHostGenerator : IHostGenerator
    {
        private readonly IDotnetCli _dotnetCli;
        private readonly DotnetHostGenDto _dto;


        public DotnetHostGenerator(IDotnetCli dotnetCli, DotnetHostGenDto dto)
        {
            _dotnetCli = dotnetCli;
            this._dto = dto;
        }


        public async Task<IEnumerable<FileSystemInfo>> GenerateHostAsFilesAsync(Host host)
        {
            var isDotnetInstalled = await _dotnetCli.IsDotNetInstalledAsync(_dto.Version);

            if (!isDotnetInstalled)
            {
                throw new Exception($"Dotnet version: {_dto.Version} is not installed");
            }

            var isTemplateInstalled = await _dotnetCli.IsTemplateInstalledAsync(_dto.Template);

            if (!isDotnetInstalled)
            {
                await _dotnetCli.InstallTemplateNugetAsync(_dto.Nuget);
            }

            var path = Path.Combine(host.GeneratedCodesDirectory);

            await _dotnetCli.CreateTemplateAsync(_dto.Template, host.Title, path);

            var files = new List<FileSystemInfo>();
            var directories = Directory.GetDirectories(path).Except(["obj", "bin"]).Select(x => new DirectoryInfo(x));
            foreach (var dir in directories)
            {
                files.AddRange(dir.GetFiles("*", SearchOption.AllDirectories));
            }

            return files;
        }
    }
}