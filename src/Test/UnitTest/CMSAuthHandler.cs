using CMS.WebApi.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace UnitTest
{
    public class CMSAuthHandler : AuthorizationHandler<AuthRequirement>
    {
        private readonly ILogger<CMSAuthHandler>? _logger;

        public CMSAuthHandler(ILogger<CMSAuthHandler>? logger)
        {
            _logger = logger;
        }

        public CMSAuthHandler()
        {

        }


        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthRequirement requirement)
        {
            //const string INFO_MESSAGE = "Success constext of requirement @{0} is @{1}";

            if (HasRequirement(context, requirement))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();

            }

            _logger?.LogInformation("Success constext of requirement @{0} is @{1}", requirement.GetType().Name, context.HasSucceeded);

            return Task.CompletedTask;
        }

        private bool HasRequirement(AuthorizationHandlerContext context, AuthRequirement requirement)
        {
            const string DEBUG_MESSAGE = "There is @{0} requirement!";

            bool hasRequirement = context.PendingRequirements.Contains(requirement);

            _logger?.LogDebug(DEBUG_MESSAGE, requirement.GetType().Name);

            return hasRequirement;
        }
    }
}