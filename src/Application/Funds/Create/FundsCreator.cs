using Domain.Funds.Models;
using Domain.Funds.Repositories;

namespace Application.Funds.Create;

public class FundsCreator(
    IFundsRepository fundsRepository
)
{
    public async Task<Fund> Create(Guid? fundId, string? fundName, string? fundDescription)
    {
        var fundToCreate = new Fund(
            new FundId(fundId ?? Guid.NewGuid()),
            new FundName(fundName),
            new FundDescription(fundDescription),
            new FundTotalAmount(0));
        return await fundsRepository.Create(fundToCreate);
    }
}