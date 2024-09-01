using Infrastructure.Persistence.EntityFramework;
using Infrastructure.Persistence.EntityFramework.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            .WithImage("postgres:16.3")
            .Build();
    }

    public MockApp App { get; set; }
    public HttpClient Client { get; set; }

    public async Task InitializeAsync()
    {
        await _postgreSqlContainer.StartAsync();
        App = new MockApp(_postgreSqlContainer.GetConnectionString());
        Client = App.CreateClient();
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
            builder.ConfigureServices(services =>
            {
                // Remove the existing database context.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<PfpTransactionsApiDatabaseContext>));

                if (descriptor != null) services.Remove(descriptor);

                // Configure the new database context.
                services.AddDbContext<PfpTransactionsApiDatabaseContext>(options =>
                {
                    options.UseNpgsql(_connectionString);
                });
            });
        }
    }
}

[CollectionDefinition(nameof(IntegrationFixtureCollection))]
public class IntegrationFixtureCollection : ICollectionFixture<IntegrationFixture>
{
}

[Collection(nameof(IntegrationFixtureCollection))]
public class IntegrationTest : IAsyncLifetime
{
    public IntegrationTest(IntegrationFixture integrationFixture)
    {
        IntegrationFixture = integrationFixture;
    }

    public IntegrationFixture IntegrationFixture { get; }
    public HttpClient Client => IntegrationFixture.Client;
    public IServiceScope Scope { get; set; }
    public IServiceProvider Services => Scope.ServiceProvider;

    public async Task InitializeAsync()
    {
        // TODO: see differences with CreateAsyncScope and use it instead if it is better.
        Scope = IntegrationFixture.App.Services.CreateScope();
        var databaseContext = Services.GetRequiredService<PfpTransactionsApiDatabaseContext>();
        await databaseContext.Database.EnsureCreatedAsync();
        // TODO: delete this example and try to use Bogus or something to fake data.
        var fund = new Fund
        {
            Id = Guid.NewGuid(), IsDeleted = false, Name = "fund1", InternalId = 1
        };
        List<Category> categories =
        [
            new Category
            {
                Id = 0, IsDeleted = false, Name = "Category1", FundId = fund.Id
            }
        ];
        fund.Categories = categories;
        await databaseContext.AddAsync(fund);
        await databaseContext.AddAsync(categories[0]);
        await databaseContext.AddRangeAsync(new List<Transaction>
        {
            new()
            {
                Amount = 10, Category = categories[0], CategoryId = categories[0].Id, IsDeleted = false,
                Id = Guid.NewGuid(), InternalId = 1, IsSplit = false, SplitTransactions = []
            },
            new()
            {
                Amount = 50, Category = categories[0], CategoryId = categories[0].Id, IsDeleted = false,
                Id = Guid.NewGuid(), InternalId = 2, IsSplit = false, SplitTransactions = []
            }
        });
        databaseContext.SaveChangesAsync().Wait();
    }

    // TODO: breakpoint to know how many times is called for each tests executed.
    public async Task DisposeAsync()
    {
        var databaseContext = Services.GetRequiredService<PfpTransactionsApiDatabaseContext>();
        // TODO: see the exception thrown here (something of disposable... see the error).
        await databaseContext.Database.EnsureDeletedAsync();
    }
}