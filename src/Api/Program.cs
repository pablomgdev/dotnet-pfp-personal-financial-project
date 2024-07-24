using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add API versioning.
builder.Services
    .AddApiVersioning(options =>
    {
        // To set the current API version.
        options.DefaultApiVersion = new ApiVersion(1, 0);
        // To use the default API version if it is not specified.
        options.AssumeDefaultVersionWhenUnspecified = true;
        // To send a header with the supported versions.
        options.ReportApiVersions = true;
        // To indicate the way to indicate the version.
        options.ApiVersionReader = new Asp.Versioning.UrlSegmentApiVersionReader();
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();