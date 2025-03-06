using Asp.Versioning.ApiExplorer;
using Asp.Versioning;

namespace Api.Configuration
{
    internal class ApiConfiguration
    {
        internal const string API_NAME = "MojeAlzaApi";

        internal static void ApiVersioningSetup(ApiVersioningOptions options)
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Enforce versioning via URL only
        }

        internal static void ApiExplorerSetup(ApiExplorerOptions options)
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        }
    }
}
