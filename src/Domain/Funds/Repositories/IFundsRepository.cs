using Domain.Funds.Models;

namespace Domain.Funds.Repositories;

public interface IFundsRepository
{
    Task<Fund?> Get(FundId id);
    Task<Fund> Create(Fund fund);
}