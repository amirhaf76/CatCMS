using Microsoft.AspNetCore.Authorization;

namespace CMSApi
{
    public class CustomizedAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomizedAuthorizeAttribute(string policy) : base(policy)
        {

        }
    }
}
