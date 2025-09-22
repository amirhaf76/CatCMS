using CMS.Persistence.Models;
using CMS.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Text;
using Xunit.Abstractions;
using GeneratedApi = CMS.Infrastructure.GeneratedAPIs.CMSAPI;


namespace UnitTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutput;

        public UnitTest1(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
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

        [Fact]
        public void PlayGround()
        {
            // AddDirectory("D:\\Books and PDFs", 1); // 1
            var path = "c:\\ii\\fsd\\fsd\\fdgdf\\f\\dsfsaaa\\fds";
            _testOutput.WriteLine(Path.GetPathRoot(path)?.ToString() ?? "<>");
            _testOutput.WriteLine(Path.IsPathRooted(path).ToString());
            _testOutput.WriteLine(Path.TrimEndingDirectorySeparator(path));
            _testOutput.WriteLine(Path.GetFileName(path));
            _testOutput.WriteLine(Path.GetDirectoryName(path));
            _testOutput.WriteLine(Path.GetDirectoryName(Path.GetDirectoryName(path)));

            //foreach (var item in path.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            //{
            //    _testOutput.WriteLine(item);
            //}
            //_testOutput.WriteLine("end");
            //foreach (var item in Path.GetInvalidFileNameChars())
            //{
            //    _testOutput.WriteLine(item.ToString());
            //}
            //_testOutput.WriteLine(string.Join(',', Directory.GetDirectories("\\")));

        }


        [Fact]
        public void PlayGround2()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };

            var iterate = numbers as IEnumerable<int>;

            foreach (var item in iterate)
            {
                _testOutput.WriteLine($"num {item}");
            }

            numbers.Remove(1);

            foreach (var item in iterate)
            {
                _testOutput.WriteLine($"num {item}");
            }
        }


        [Fact]
        public void Test2()
        {
            var destination = new DirectoryInfo("test2");

            destination.Create();

            var path = "D:\\Programing\\Work_space\\C#\\CMS\\src\\SampleHost";

            var source = new DirectoryInfo(path);

            foreach (var file in source.EnumerateFiles())
            {
                File.Copy(file.FullName, Path.Combine(destination.FullName, file.Name), true);
            }


            foreach (var directory in source.EnumerateDirectories("*", new EnumerationOptions { RecurseSubdirectories = true, MaxRecursionDepth = 10 }))
            {
                Directory.CreateDirectory(Path.Join(destination.FullName, directory.Name));
            }
        }



        [Fact]
        public void Test4()
        {
            var dbContextMock = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<User>>();

            var list = new List<User>();
            dbContextMock.Setup(db => db.Set<User>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(set => set.AsNoTracking()).Returns(list.AsQueryable());
            var userRepository = new UserRepository(dbContextMock.Object);

            var user = dbSetMock.Object
                .AsNoTracking()
                .Include(user => user.Hosts);

            _testOutput.WriteLine(user.ToQueryString());

        }

        [Fact]
        public async Task Test5Async()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7077")
            };
            var client = new GeneratedApi.AuthenticationClient(httpClient);

            var inventories = await client.PostLoginAsync(new GeneratedApi.LoginRequest
            {
                Password = "123456",
                Username = "amin"
            });

            _testOutput.WriteLine(inventories.Result);
        }

        [Fact]
        public void Test6()
        {

            var payload = $"{{\"sub\":\"1234567890\",\"name\":\"John Doe\",\"admin\":true,\"iat\":1516239022}}";
            _testOutput.WriteLine(payload);

            var base64Payload = Convert.ToBase64String(Encoding.UTF8.GetBytes(payload), Base64FormattingOptions.None);

            _testOutput.WriteLine(base64Payload);

            payload = Encoding.UTF8.GetString(Convert.FromBase64String(base64Payload));

            _testOutput.WriteLine(payload);

            var jwt = "eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0=";
            payload = Encoding.UTF8.GetString(Convert.FromBase64String(jwt));

            _testOutput.WriteLine(payload);


        }
    }
}