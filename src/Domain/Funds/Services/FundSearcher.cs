using Domain.Funds.Models;
using Domain.Funds.Repositories;

namespace Domain.Funds.Services;

public class FundSearcher(
    IFundsRepository fundsRepository
)
{
    public async Task<Fund?> Search(Guid id)
    {
        var fundId = new FundId(id);
        var fund = await fundsRepository.Get(fundId);
        return fund;
    }
}