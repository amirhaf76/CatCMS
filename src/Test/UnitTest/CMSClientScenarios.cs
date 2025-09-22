using CMS.Client.Services;
using CMS.Client.Services.Abstraction;
using CMS.Client.Services.Abstraction.DTOs;
using CMS.Infrastructure.GeneratedAPIs.CMSAPI;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;

namespace UnitTest
{
    public class CMSClientScenarios
    {
        private readonly ITestOutputHelper _testOutput;

        public CMSClientScenarios(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }


        [Fact]
        public async Task AccountManagement_LoginAsyncWithMockData_PostLoginAPIMustBeCalled()
        {
            // Arrangement
            /**
             * Header:
             * {
             *    "alg": "HS256",
             *    "typ": "JWT"
             * }
             * Payload:
             * {
             *    "sub": "1234567890",
             *    "name": "John Doe",
             *    "admin": true,
             *    "iat": 1516239022
             * }
             * 
             */
            var mockUsername = "MockUsername";
            var mockPassword = "MockPassword";
            var mockClient = new Mock<IAuthenticationClient>();
            var jwtString = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0.KMUFsIDTnFmyG3nMiGM6H9FNFUROf3wh7SmqJp-QV30";
            var headers = new Dictionary<string, IEnumerable<string>>();
            var stubSwaggerResponse = new SwaggerResponse<string>(200, headers, jwtString);
            var stubLogger = new Mock<ILogger<AccountManagement>>();
            var mockLoginDto = new LoginDto()
            {
                Username = mockUsername,
                Password = mockPassword,
            };

            mockClient
                .Setup(c => c.PostLoginAsync(It.IsAny<LoginRequest>()))
                .Returns(Task.FromResult(stubSwaggerResponse));

            var management = new AccountManagement(mockClient.Object, stubLogger.Object);

            // Action
            var result = await management.LoginAsync(mockLoginDto);

            // Assertion
            mockClient.Verify(x => x.PostLoginAsync(It.Is<LoginRequest>(r => r.Username == mockUsername && r.Password == mockPassword)), Times.Once);
            mockClient.VerifyNoOtherCalls();

            result.Identity.Should().NotBeNull();
            result.Identity.IsAuthenticated.Should().BeTrue();

        }
    }
}
