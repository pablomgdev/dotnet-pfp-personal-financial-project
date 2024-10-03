using Domain.Funds.Exceptions;
using Domain.Funds.Models;
using Domain.Funds.Repositories;
using Domain.Funds.Services;

namespace Application.Funds;

public class FundsCreator(
    IFundsRepository fundsRepository
)
{
    // Creating without the dependency injection makes easier testing.
    //  It adds other problems but let us try if it is worth it.
    private readonly FundSearcher _fundSearcher = new(fundsRepository);

    public async Task<Fund> Invoke(Guid? fundId, string? fundName, string? fundDescription)
    {
        Fund? fundFound = null;
        if (fundId.HasValue) fundFound = await _fundSearcher.Search(fundId.Value);

        if (fundFound is not null) throw new FundAlreadyExistsException(fundFound.Id);

        var fundToCreate = new Fund(
            new FundId(fundId ?? Guid.NewGuid()),
            new FundName(fundName),
            new FundDescription(fundDescription),
            new FundTotalAmount(0));
        return await fundsRepository.Create(fundToCreate);
    }
}