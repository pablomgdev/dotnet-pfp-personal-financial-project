using Api.Controllers.Base;
using Asp.Versioning;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiVersion("1.0")]
[Produces("application/json")]
public class TransactionsController(ILogger<TransactionsController> logger) : ApiControllerBase
{
    /// <summary>
    ///     Get incomes and expenses.
    /// </summary>
    /// <param name="request">Request data to filter the transactions.</param>
    /// <returns>Returns all the incomes and expenses.</returns>
    /// <response code="200">Incomes and expenses returned successfully.</response>
    [ApiVersion("1.0")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetTransactionsResponse>> Get([FromQuery] GetTransactionsRequest request)
    {
        /*
         * NOTES:
         * ActionResult [ProducesResponseType(200, Type = typeof(Product))] is simplified to [ProducesResponseType(200)].
         * ActionResult return new ObjectResult(T); is simplified to return T.
         * Create a new Contract project to add the DTOs like Transaction.
         */
        return new GetTransactionsResponse();
    }
}