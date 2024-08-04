using AutoMapper;
using Domain.Transactions.Models;

namespace Api.Profiles;

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<Transaction, Contracts.Transactions.Transaction>()
            .ForMember(
                contractTransaction => contractTransaction.Id,
                domainTransaction => domainTransaction.MapFrom(x => x.Id.Value)
            )
            .ForMember(
                contractTransaction => contractTransaction.Description,
                domainTransaction => domainTransaction.MapFrom(x => x.TransactionDescription.Value)
            ).ForMember(
                contractTransaction => contractTransaction.Amount,
                domainTransaction => domainTransaction.MapFrom(x => x.TransactionAmount.Value)
            ).ForMember(
                contractTransaction => contractTransaction.IsSplit,
                domainTransaction => domainTransaction.MapFrom(x => x.IsSplit)
            ).ForMember(
                contractTransaction => contractTransaction.UserId,
                domainTransaction => domainTransaction.MapFrom(x => x.UserId.Value)
            );
    }
}