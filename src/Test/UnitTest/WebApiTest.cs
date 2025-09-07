using CMSApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Moq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Xunit.Abstractions;

namespace UnitTest
{
    public class WebApiTest
    {
        private readonly ITestOutputHelper _testOutput;

        public WebApiTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
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
    }
}
