using CMSClient.Services;
using CMSClient.Services.Abstraction;
using Infrastructure.GeneratedAPIs.CMSAPI;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;

namespace UnitTest
{
    public class CMSClientUnitTest
    {
        private ITestOutputHelper _testOutput;

        public CMSClientUnitTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }


        [Fact]
        public async Task CreateCMS()
        {
            var mockClient = new Mock<IAuthenticationClient>();

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
            var jwtString = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0.KMUFsIDTnFmyG3nMiGM6H9FNFUROf3wh7SmqJp-QV30";
            var headers = new Dictionary<string, IEnumerable<string>>();
            var mockSwaggerResponse = new SwaggerResponse<string>(200, headers, jwtString);
            var loggerMock = new Mock<ILogger<AccountManagement>>();

            mockClient
                .Setup(c => c.PostLoginAsync(It.IsAny<LoginRequest>()))
                .Returns(Task.FromResult(mockSwaggerResponse));

            IAccountManagement management = new AccountManagement(mockClient.Object, loggerMock.Object);


            var result = await management.LoginAsync(new CMSClient.Services.Abstraction.DTOs.LoginDto());

            mockClient.Verify(x => x.PostLoginAsync(It.IsAny<LoginRequest>()), Times.Once);
            mockClient.VerifyNoOtherCalls();

            result.Identity.Should().NotBeNull();
            result.Identity.IsAuthenticated.Should().BeTrue();

        }
    }
}
