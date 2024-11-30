using Api.Controllers.Base;
using Api.Mappers;
using Application.Transactions.Get;
using Asp.Versioning;
using Contracts.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiVersion("1.0")]
public class TransactionsController(
    TransactionsGetter transactionsGetter
) : JsonApiControllerBase
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
            .Select(domainTransaction => domainTransaction.MapToDto())
            .ToList();
        return new GetTransactionsResponse(responseData);
    }
}