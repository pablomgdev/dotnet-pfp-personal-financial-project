using System.Reflection;
using System.Text.Json.Serialization;
using Api.Options;
using Application.Categories;
using Application.Funds;
using Application.Shared;
using Application.Transactions.Get;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Domain.Categories.Repositories;
using Domain.Funds.Repositories;
using Domain.Funds.Services;
using Domain.Transactions.Repositories;
using Infrastructure.Persistence.EntityFramework;
using Infrastructure.Persistence.EntityFramework.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
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

    // Dependency injection
    // Application
    builder.Services.AddTransient<TransactionsGetter>();
    builder.Services.AddTransient<FundsCreator>();
    builder.Services.AddTransient<CategoriesCreator>();

    // Domain (most of the cases this is instanciated directly in the application layer use of case)
    builder.Services.AddTransient<FundFinder>();
    builder.Services.AddTransient<FundSearcher>();
    builder.Services.AddTransient<TextNormalizer>();

    // Infrastructure
    var databaseConnectionString = builder.Configuration.GetConnectionString("Database");
    builder.Services.AddDbContext<PfpTransactionsApiDatabaseContext>(
        options => { options.UseNpgsql(databaseConnectionString); });

    builder.Services.AddTransient<ITransactionsRepository, EfTransactionsRepository>();
    builder.Services.AddTransient<IFundsRepository, EfFundsRepository>();
    builder.Services.AddTransient<ICategoriesRepository, EfCategoriesRepository>();
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

public partial class Program
{
}