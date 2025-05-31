using CMSCore;
using CMSCore.Abstraction;
using CMSCore.Component;

using Xunit.Abstractions;

namespace UnitTest
{
    public class UnitTest1
    {
        private ITestOutputHelper _testOutput;

        public UnitTest1(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void Build_SomeDirectoriesAndFiles_MustBeExist()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Myapp_1");

            var appStruct = new AppFileStructureBuilder("Myapp_1", new FileSystem());

			appStruct
                .AddDirectoryAndChangeWorkingDirectory("txtFolder")
                .AddFile("hello.World.txt", "Hello World number 1")
                .AddFile("hello.World.2.txt", "Hello World number 2")
                .SetWorkingDirectoryToRoot()
                .AddDirectory("directory_1")
                .AddDirectory("directory_2")
                .AddDirectory("directory_3")
                .AddDirectoryAndChangeWorkingDirectory("directory_level_1")
                .AddDirectoryAndChangeWorkingDirectory("directory_level_2")
                .AddDirectoryAndChangeWorkingDirectory("directory_level_3")
                .SetWorkingDirectoryToRoot();

            // Action
            _testOutput.WriteLine(appStruct.GetStructureView());

            appStruct.Build(Directory.GetCurrentDirectory());

            // Assertion
            Directory.EnumerateFileSystemEntries(path).Should()
                .Contain(x => x.Contains("txtFolder"))
                .And.Contain(x => x.Contains("directory_1"))
                .And.Contain(x => x.Contains("directory_2"))
                .And.Contain(x => x.Contains("directory_3"))
				.And.Contain(x => x.Contains("directory_level_1"));


            Directory.EnumerateFileSystemEntries(Path.Combine(path, "txtFolder")).Should()
                .Contain(x => x.Contains("hello.World.txt"))
                .And.Contain(x => x.Contains("hello.World.2.txt"));


            Directory.EnumerateFileSystemEntries(Path.Combine(path, "directory_level_1"))
                .Should().Contain(x => x.Contains("directory_level_2"));


			Directory.EnumerateFileSystemEntries(Path.Combine(path, "directory_level_1", "directory_level_2"))
                .Should().Contain(x => x.Contains("directory_level_3"));

			var targetDirctory = Path.Combine(Directory.GetCurrentDirectory(), "Myapp_1");
			Directory.Delete(targetDirctory, true);
			_testOutput.WriteLine($"\"{targetDirctory}\" directory is removed.");
		}

        [Fact]
        public void AddFilesLike_SomeDirectoriesAndFiles_MustBeExist()
        {
            var appStruct = new AppFileStructureBuilder("Myapp_2", new FileSystem());
            var path = @"D:\Programing\Work_space\C#\CMS\src\SampleHost";

            appStruct
                .AddDirectoryAndChangeWorkingDirectory("Properties")
                .AddFilesLike(Path.Combine(path, "Properties"))
                .SetWorkingDirectoryToRoot()
                .AddDirectoryAndChangeWorkingDirectory("wwwroot")
                .AddFilesLike(Path.Combine(path, "wwwroot"))
                .SetWorkingDirectoryToRoot()
                .AddDirectoryAndChangeWorkingDirectory("Pages")
                .AddFilesLike(Path.Combine(path, "Pages"))
                .SetWorkingDirectoryToRoot()
                .AddFilesLike(path);

            _testOutput.WriteLine(appStruct.GetStructureView());

            appStruct.Build(Directory.GetCurrentDirectory());

            var targetDirctory = Path.Combine(Directory.GetCurrentDirectory(), "Myapp_2");
			Directory.Delete(targetDirctory, true);
            _testOutput.WriteLine($"\"{targetDirctory}\" directory is removed.");
        }

        [Fact]
        public void TestScenario3()
        {
            var path = @"D:\Programing\Work_space\C#\CMS\src\SampleHost";
            var directories = Directory
                .EnumerateDirectories(path, "*", new EnumerationOptions { RecurseSubdirectories = true, MaxRecursionDepth = 10 })
                .ToList();
            directories.Add(path);
            var files = directories.SelectMany(directory => Directory.GetFiles(directory));

            var destiantion = Path.Combine(Directory.GetCurrentDirectory(), "newMyApp");

            Directory.CreateDirectory(destiantion);


            foreach (var d in directories)
            {
                var relativePath = Path.GetRelativePath(path, d);

                var newPath = Path.Combine(Directory.GetCurrentDirectory(), "newMyApp", relativePath);

                Directory.CreateDirectory(newPath);
            }


            foreach (var file in files)
            {
                var relativePath = Path.GetRelativePath(path, file);

                File.Copy(file, Path.Combine(destiantion, relativePath));
            }

			var targetDirctory = Path.Combine(Directory.GetCurrentDirectory(), "newMyApp");
			Directory.Delete(targetDirctory, true);
			_testOutput.WriteLine($"\"{targetDirctory}\" directory is removed.");

		}
    }
}