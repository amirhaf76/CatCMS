using CMS.Application.Abstraction.Services;
using CMS.Application.Services;
using CMS.Domain.Entities;
using CMS.Domain.Repository;
using CMS.Domain.ValueObjects;
using CMS.Presentation.Controllers.DTOs.Requests;
using CMS.WebApi.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Xunit.Abstractions;

namespace UnitTest
{
    public class WebApiTest
    {
        private readonly ILogger<WebApiTest> _testLogger;
        private readonly LoggerFactory _testLoggerFactory;

        public WebApiTest(ITestOutputHelper testOutput)
        {
            _testLoggerFactory = new LoggerFactory();

            _testLoggerFactory.AddProvider(new TestLoggerProvider(testOutput, LogLevel.Debug));

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

            var fakeUser = User.Create(UserId.Create(1), Email.Create(string.Empty), "user_1", string.Empty, UserStatus.Active);
            
            var fakeHost = new Host
            {
                Id = Guid.NewGuid(),
            };
            fakeHost.UpdateOwner(fakeUser);

            stubUserProvider
                .Setup(x => x.UserIdV2)
                .Returns(fakeUser.UserId);

            stubHostRepository
                .Setup(h => h.GetHostAsync(fakeUser.UserId.Value, fakeHost.Id))
                .Returns(Task.FromResult((Host?)fakeHost));


            var cmsService = new CMSService(stubHostRepository.Object,
                                            stubHostGenerator.Object,
                                            stubUserProvider.Object);

            var responsedHost = await cmsService.GetHostAsync(fakeHost.Id);

            responsedHost.Should().BeEquivalentTo(fakeHost);
        }

        [Fact]
        public void Test3()
        {
            var name = "amir";
            var family = "firouzkouhi";

            _testLogger.LogInformation("hello {name}, {family}", name, family);
        }

        [Fact]
        public void Test4()
        {
            var str = JsonSerializer.Serialize(new { Name = "Jack" }, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            using (_testLogger.BeginScope(new { ScopeName = "MyScope" }))
            {
                _testLogger.LogDebug(message: str);

            }

            using (_testLogger.BeginScope(str))
            {
                _testLogger.LogDebug(message: "fdsfasdfadsf");

            }
        }

        private void FutureTest()
        {
            var stubHttpContextAccessor = new Mock<IHttpContextAccessor>();
            var loger = _testLoggerFactory.CreateLogger<CMSService>();
            var stubHttpContext = new Mock<HttpContext>();

            var theUser = User.Create(UserId.Create(1), Email.Create(string.Empty), "user_1", string.Empty, UserStatus.Active);
            Host theHost = new()
            {
                Id = Guid.NewGuid(),
            };

            theHost.UpdateOwner(theUser);

            var fakeClaimsIdentity = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.NameId, theHost.OwnerId.Value.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, theHost.Owner.Username),
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
}
