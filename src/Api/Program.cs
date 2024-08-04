using System.Reflection;
using System.Text.Json.Serialization;
using Api.Options;
using Application.Transactions.Get;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Domain.Transactions.Repositories;
using Infrastructure.Persistence.EntityFramework;
using Infrastructure.Persistence.EntityFramework.Implementations;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });
    builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

    // Add API versioning.
    builder.Services
        .AddApiVersioning(options =>
        {
            // To set the current API version.
            options.DefaultApiVersion = new ApiVersion(2, 0);
            // To use the default API version if it is not specified.
            options.AssumeDefaultVersionWhenUnspecified = true;
            // To send a header with the supported versions.
            options.ReportApiVersions = true;
            // To indicate the way to indicate the version.
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

    builder.Services.ConfigureHttpJsonOptions(options =>
    {
        options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    // Dependency injection
    // Application
    builder.Services.AddSingleton<TransactionsGetter>();

    // Domain

    // Infrastructure
    builder.Services.AddSingleton<PfpTransactionsApiDatabaseContext>();
    builder.Services.AddSingleton<ITransactionsRepository, EfTransactionsRepository>();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.ApiVersion.ToString()
                );
        });
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}