using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Configuration
{
    public class SwagerConfigureOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider apiVersionDescriptionProvider;

        public SwagerConfigureOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            this.apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription versionDescription in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(versionDescription.GroupName, new OpenApiInfo()
                {
                    Title = ApiConfiguration.API_NAME,
                    Version = versionDescription.ApiVersion.ToString()
                });
            }
        }
    }
}
