using CMSApi.Abstraction.Services;
using CMSApi.Authentication;
using CMSApi.Services;
using CMSCore.Abstraction;
using CMSRepository.Abstractions;
using CMSRepository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Xunit.Abstractions;

namespace UnitTest
{
    public class WebApiTest
    {
        private readonly ILogger<WebApiTest> _testLogger;
        private readonly ILoggerFactory _testLoggerFactory;

        public WebApiTest(ITestOutputHelper testOutput)
        {
            _testLoggerFactory = new LoggerFactory();

            _testLoggerFactory.AddProvider(new TestLoggerProvider(testOutput));

            _testLogger = _testLoggerFactory.CreateLogger<WebApiTest>();
        }


        [Fact]
        public async Task Test()
        {
            var stubAuthRequirement = new AuthRequirement();
            var stubClaimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity("Test"));
            var stubAuthHandlerContext = new AuthorizationHandlerContext([stubAuthRequirement], stubClaimsPrincipal, null);

            AuthorizationHandler<AuthRequirement> authHandler = new CMSAuthHandler();

            await authHandler.HandleAsync(stubAuthHandlerContext);

            stubAuthHandlerContext?.HasSucceeded.Should().BeTrue();
        }

        [Fact]
        public async Task Test1()
        {
            var stubAuthorizeMock = new Mock<IOptions<AuthorizationOptions>>();
            var stubAuthorizationOptions = new AuthorizationOptions();

            //stubAuthorizationOptions.AddPolicy("opp", new AuthorizationPolicyBuilder().AddRequirements().Build());

            stubAuthorizeMock.SetupGet(x => x.Value).Returns(stubAuthorizationOptions);

            DefaultAuthorizationPolicyProvider policyProvider = new CustomizedAuthorizationPolicyProvider(stubAuthorizeMock.Object);

            AuthorizationPolicy? authorizationPolicy = await policyProvider.GetPolicyAsync("opp");

            authorizationPolicy?.Requirements.OfType<AuthRequirement>().Should().NotBeEmpty();
        }

        [Fact]
        public async Task Test2()
        {
            var loger = _testLoggerFactory.CreateLogger<CMSService>();

            var stubHostRepository = new Mock<IHostRepository>();
            var stubUserProvider = new Mock<IUserProvider>();
            var stubHostGenerator = new Mock<IHostGenerator>();

            var fakeUser = new User
            {
                Id = 1,
                Username = "user_1"
            };

            var fakeHost = new Host
            {
                Id = Guid.NewGuid(),
                Creator = fakeUser
            };

            stubUserProvider
                .Setup(x => x.UserId)
                .Returns(fakeUser.Id);

            stubHostRepository
                .Setup(h => h.GetHostAsync(fakeUser.Id, fakeHost.Id))
                .Returns(Task.FromResult((Host?)fakeHost));


            ICMSService cmsService = new CMSService(stubHostRepository.Object,
                                                    stubHostGenerator.Object,
                                                    stubUserProvider.Object,
                                                    logger: loger);

            var responsedHost = await cmsService.GetHostAsync(fakeHost.Id);

            responsedHost.Should().BeEquivalentTo(fakeHost);
        }

        [Fact]
        public async Task Test3()
        {
            var name = "amir";
            var family = "firouzkouhi";

            _testLogger.LogInformation("hello {name}, {family}", name, family);
        }

        private void FutureTest()
        {
            var stubHttpContextAccessor = new Mock<IHttpContextAccessor>();
            var loger = _testLoggerFactory.CreateLogger<CMSService>();
            var stubHttpContext = new Mock<HttpContext>();
            Host theHost = new Host
            {
                Id = Guid.NewGuid(),
                Creator = new User
                {
                    Id = 1,
                    Username = "user_1"
                }
            };

            var fakeClaimsIdentity = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.NameId, theHost.Creator.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, theHost.Creator.Username),
            ], nameof(Test2));

            var fakeClaimsPrincipal = new ClaimsPrincipal(fakeClaimsIdentity);

            stubHttpContext
                .Setup(h => h.User)
                .Returns(fakeClaimsPrincipal);

            stubHttpContextAccessor
                .Setup(h => h.HttpContext)
                .Returns(stubHttpContext.Object);

        }
    }

    public class TestLoggerProvider : ILoggerProvider
    {
        private readonly ITestOutputHelper _testOutputHelper;


        public TestLoggerProvider(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ILogger ILoggerProvider.CreateLogger(string categoryName)
        {
            return new TestLogger(_testOutputHelper);
        }
    }

    public class TestLogger : ILogger
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TestLogger(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                var eventStr = eventId.Id != 0 ? $"[{eventId.Id}]" : string.Empty;
                var logMessage = formatter.Invoke(state, exception);

                _testOutputHelper.WriteLine("[{0}]{1}: {2}", logLevel, eventStr, logMessage);

                if (exception != null)
                {
                    _testOutputHelper.WriteLine("Exception:\n{\n} // End of Exception", exception);
                }
            }
        }
    }
}
