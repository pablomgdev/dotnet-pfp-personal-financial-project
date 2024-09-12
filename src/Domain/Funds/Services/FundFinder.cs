using Domain.Funds.Exceptions;
using Domain.Funds.Models;
using Domain.Funds.Repositories;

namespace Domain.Funds.Services;

public class FundFinder(
    IFundsRepository fundsRepository
)
{
    public async Task<Fund> Find(Guid id)
    {
        var fundId = new FundId(id);
        var fund = await fundsRepository.Get(fundId);
        return fund ?? throw new FundNotFoundException(fundId);
    }
}