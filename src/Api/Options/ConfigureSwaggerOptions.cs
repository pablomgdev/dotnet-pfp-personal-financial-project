using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Options;

public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
            options.SwaggerDoc(description.GroupName, CreateOpenApiWithVersionInfo(description));
    }

    private static OpenApiInfo CreateOpenApiWithVersionInfo(ApiVersionDescription description)
    {
        return new OpenApiInfo
        {
            Title = $"Personal Finance Project API {description.GroupName}",
            Version = description.ApiVersion.ToString()
        };
    }
}