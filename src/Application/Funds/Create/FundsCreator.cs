using Domain.Funds.Models;
using Domain.Funds.Repositories;

namespace Application.Funds.Create;

public class FundsCreator(
    IFundsRepository fundsRepository
)
{
    public async Task<Fund> Create(Guid? fundId, string? fundName, string? fundDescription)
    {
        var fundToCreateId = new FundId(fundId ?? Guid.NewGuid());
        //  Infrastructure Fund model could have exclusive properties whose values would be set in the repository before
        //  been inserted.
        var fundToCreate = new Fund(
            fundToCreateId,
            new FundName(fundName),
            new FundDescription(fundDescription),
            new FundTotalAmount(0));
        return await fundsRepository.Create(fundToCreate);
    }
}