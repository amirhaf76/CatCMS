using Microsoft.AspNetCore.Authorization;

namespace CMS.WebApi.Authentication
{
    public class CustomizedAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomizedAuthorizeAttribute(string policy) : base(policy)
        {

        }
    }
}
