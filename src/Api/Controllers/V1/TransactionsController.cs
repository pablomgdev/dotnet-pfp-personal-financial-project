using Api.Controllers.Base;
using Application.Transactions.Get;
using Asp.Versioning;
using Contracts.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiVersion("1.0")]
[Produces("application/json")]
public class TransactionsController(
    ILogger<TransactionsController> logger,
    TransactionsGetter transactionsGetter
) : ApiControllerBase
{
    /// <summary>
    ///     Get incomes and expenses.
    /// </summary>
    /// <param name="request">Request data to filter the transactions.</param>
    /// <returns>Returns all the incomes and expenses.</returns>
    /// <response code="200">Incomes and expenses returned successfully.</response>
    /// <response code="500">Internal server error.</response>
    [MapToApiVersion("1.0")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GetTransactionsResponse>> Get([FromQuery] GetTransactionsRequest request)
    {
        var transactions = await transactionsGetter.Get();
        var responseData = transactions
            .Select(domainTransaction => new Transaction
            {
                Id = domainTransaction.Id.Value,
                Amount = domainTransaction.Amount.Value,
                Description = domainTransaction.Description.Value,
                CreatedDate = domainTransaction.CreatedDate,
                DeletedDate = domainTransaction.DeletedDate,
                IsDeleted = domainTransaction.IsDeleted,
                IsSplit = domainTransaction.IsSplit,
                UpdatedDate = domainTransaction.UpdatedDate,
                TransactionNotSplitInternalId = domainTransaction.TransactionNotSplitInternalId,
                UserId = domainTransaction.UserId.Value
            }).ToList();
        return new GetTransactionsResponse(responseData);
    }
}