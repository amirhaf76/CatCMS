using System.Diagnostics;

namespace CMS.Infrastructure.DotNetCLI
{
    public class BaseDotnetCli
    {
        protected static async Task<DotnetCliResult> RunDotnetCommandAsync(string commandAndArguments)
        {
            return await RunDotnetCommandAsync(commandAndArguments, CancellationToken.None);
        }

        protected static async Task<DotnetCliResult> RunDotnetCommandAsync(string commandAndArguments, CancellationToken cs)
        {
            var result = new DotnetCliResult();
            var process = new Process
            {
                StartInfo = CreateProcessStartInfo(commandAndArguments)
            };

            process.Start();

            result.Output = await process.StandardOutput.ReadToEndAsync(cs);
            result.Error = await process.StandardError.ReadToEndAsync(cs);

            await process.WaitForExitAsync(cs);

            return result;
        }


        private static ProcessStartInfo CreateProcessStartInfo(string commandAndArguments)
        {
            return new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = commandAndArguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
        }


    }
}

