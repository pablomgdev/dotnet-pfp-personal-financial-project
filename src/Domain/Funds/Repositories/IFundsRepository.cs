using Domain.Funds.Models;

namespace Domain.Funds.Repositories;

public interface IFundsRepository
{
    Task<Fund> Create(Fund fund);
}