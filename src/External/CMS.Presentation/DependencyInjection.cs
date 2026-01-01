using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CMS.Presentation
{
    public static class DependencyInjection
    {
        public static IMvcBuilder AddCMSPresentationEndPoints(this IMvcBuilder builder)
        {
            builder.AddApplicationPart(typeof(DependencyInjection).Assembly);

            IServiceCollection sc = null;

            sc.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version"));
            });
            return builder;
        }
    }
}
