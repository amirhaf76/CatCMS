using Microsoft.Extensions.DependencyInjection;

namespace CMS.Presentation
{
    public static class DependencyInjection
    {
        public static IMvcBuilder AddCMSPresentationEndPoints(this IMvcBuilder builder)
        {
            builder.AddApplicationPart(typeof(DependencyInjection).Assembly);

            return builder;
        }
    }
}
