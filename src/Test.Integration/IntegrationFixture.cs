using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Testcontainers.PostgreSql;

namespace Test.Integration;

public class IntegrationFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgreSqlContainer;

    public IntegrationFixture()
    {
        _postgreSqlContainer = new PostgreSqlBuilder()
            .WithDatabase("pfp-transactions-api-database")
            // .WithExposedPort(5432)
            .WithPortBinding(5432, 5432)
            .WithUsername("postgres")
            .WithPassword("postgres")
            .WithImage("postgres:16")
            .Build();

        new WebApplicationFactory<Program>();
    }

    public async Task InitializeAsync()
    {
        await _postgreSqlContainer.StartAsync();
        var app = new MockApp(_postgreSqlContainer.GetConnectionString());
        var client = app.CreateClient();
    }

    public async Task DisposeAsync()
    {
        await _postgreSqlContainer.StopAsync();
    }

    public class MockApp : WebApplicationFactory<Program>
    {
        private readonly string _connectionString;

        public MockApp(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // TODO: continue here adding the connectionString (https://www.youtube.com/watch?v=-Dpg9fqXWGM 19:50).
            builder.ConfigureServices(services => { });
            builder.ConfigureTestServices(service => { });
        }
    }
}

[CollectionDefinition(nameof(IntegrationFixtureCollection))]
public class IntegrationFixtureCollection : ICollectionFixture<IntegrationFixture>
{
}

[Collection(nameof(IntegrationFixtureCollection))]
public class IntegrationTest
{
    public IntegrationTest(IntegrationFixture integrationFixture)
    {
        IntegrationFixture = integrationFixture;
    }

    public IntegrationFixture IntegrationFixture { get; }
}