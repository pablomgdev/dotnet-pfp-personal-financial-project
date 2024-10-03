using Infrastructure.Persistence.EntityFramework;
using Infrastructure.Persistence.EntityFramework.Models;

namespace Test.Integration.Infrastructure.Persistence;

public static class DatabaseData
{
    public static async Task Populate(PfpTransactionsApiDatabaseContext databaseContext)
    {
        // TODO: delete this example and try to use Bogus or something to fake data.
        // TODO: use design patters to fake data (motherboard, for example). -waiting add fund feature to be merged-
        var fund = new Fund
        {
            Id = Guid.NewGuid(), IsDeleted = false, Name = "fund1"
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
                Id = Guid.NewGuid(), IsSplit = false, SplitTransactions = [], Description = "Prueba1"
            },
            new()
            {
                Amount = 50, Category = categories[0], CategoryId = categories[0].Id, IsDeleted = false,
                Id = Guid.NewGuid(), IsSplit = false, SplitTransactions = [], Description = "Prueba2"
            }
        });
        databaseContext.SaveChangesAsync().Wait();
    }
}