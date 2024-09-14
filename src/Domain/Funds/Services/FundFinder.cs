using Domain.Funds.Exceptions;
using Domain.Funds.Models;

namespace Domain.Funds.Services;

public class FundFinder(
    FundSearcher fundSearcher
)
{
    public async Task<Fund> Find(Guid id)
    {
        var fund = await fundSearcher.Search(id);
        return fund ?? throw new FundNotFoundException(new FundId(id));
    }
}