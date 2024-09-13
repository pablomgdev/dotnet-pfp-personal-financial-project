using Domain.Funds.Exceptions;
using Domain.Funds.Models;
using Domain.Funds.Repositories;
using Domain.Funds.Services;

namespace Application.Funds;

public class FundsCreator(
    IFundsRepository fundsRepository,
    FundFinder fundFinder
)
{
    public async Task<Fund> Invoke(Guid? fundId, string? fundName, string? fundDescription)
    {
        Fund fundFound = null;
        if (fundId.HasValue) fundFound = await fundFinder.Find(fundId.Value);

        if (fundFound is not null) throw new FundAlreadyExistsException(fundFound.Id);

        var fundToCreate = new Fund(
            new FundId(fundId ?? Guid.NewGuid()),
            new FundName(fundName),
            new FundDescription(fundDescription),
            new FundTotalAmount(0));
        return await fundsRepository.Create(fundToCreate);
    }
}