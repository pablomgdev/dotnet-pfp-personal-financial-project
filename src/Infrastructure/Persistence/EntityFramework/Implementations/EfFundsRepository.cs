using Domain.Funds.Models;
using Domain.Funds.Repositories;
using Infrastructure.Mappers;

namespace Infrastructure.Persistence.EntityFramework.Implementations;

public class EfFundsRepository(
    PfpTransactionsApiDatabaseContext context
) : IFundsRepository
{
    public async Task<Fund?> Get(FundId id)
    {
        var fund = await context.Funds.FindAsync(id.Value);
        return fund.MapToDomainModel();
    }

    public async Task<Fund> Create(Fund fund)
    {
        var fundToCreate = fund.MapToInfrastructureModel();
        fundToCreate.CreatedDate ??= DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
        fundToCreate.UpdatedDate ??= fundToCreate.CreatedDate;
        await context.Funds.AddAsync(fundToCreate);
        await context.SaveChangesAsync();
        return fund;
    }
}