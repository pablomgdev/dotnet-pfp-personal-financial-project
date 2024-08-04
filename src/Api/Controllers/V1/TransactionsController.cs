using System.Diagnostics;
using Api.Controllers.Base;
using Application.Transactions.Get;
using Asp.Versioning;
using AutoMapper;
using Contracts.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiVersion("1.0")]
[Produces("application/json")]
public class TransactionsController(
    TransactionsGetter transactionsGetter,
    IMapper mapper,
    // TODO: add a custom logger
    ILogger<TransactionsController>? logger = null
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
        // TODO: see why null values are returned in the json response: see ConfigureHttpJsonOptions in Program.cs.
        // TODO: fix error with efficiency (see dynamic program analysis > View ASP issues).
        // TODO: see if a middleware can be created to log the elapsed time of each method called like below.
        var beforeGetTransactionsTimestamp = Stopwatch.GetTimestamp();
        var transactions = await transactionsGetter.Get();
        var afterGetTransactionsTimestamp = Stopwatch.GetTimestamp();
        logger?.LogInformation(
            $"transactionsGetter.Get() elapsed time: {Stopwatch.GetElapsedTime(beforeGetTransactionsTimestamp, afterGetTransactionsTimestamp)}");
        var responseData = transactions.Select(mapper.Map<Transaction>).ToList();
        var afterGetResponseDataTransactionsTimestamp = Stopwatch.GetTimestamp();
        logger?.LogInformation(
            $"Get responseData (LINQ Select) elapsed time: {Stopwatch.GetElapsedTime(afterGetTransactionsTimestamp, afterGetResponseDataTransactionsTimestamp)}");
        return new GetTransactionsResponse(responseData);
    }
}