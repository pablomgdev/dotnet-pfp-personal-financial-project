using Api.Controllers.Base;
using Asp.Versioning;
using Contracts.Funds;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiVersion("1.0")]
// TODO: use JsonApiControllerBase in TransactionsController and in the other classes where it is not used.
public class FundsController : JsonApiControllerBase
{
    /// <summary>
    ///     Creates a new fund.<br />
    ///     If no funds currently exist, a global fund will be created along with the new fund.
    /// </summary>
    /// <param name="request">Fund data.</param>
    /// <returns>Returns the fund already created.</returns>
    /// <response code="201">Fund created successfully.</response>
    /// <response code="500">Internal server error.</response>
    [MapToApiVersion("1.0")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CreateFundResponse>> Get([FromBody] CreateFundRequest request)
    {
        // var transactions = await transactionsGetter.Get();
        // var responseData = transactions
        //     .Select(domainTransaction => domainTransaction.MapToDto())
        //     .ToList();
        // TODO: see what to return from this endpoint (URI -there are different "Created" methods- and object -result
        //  or request or what?-).
        //  Example from microsoft:
        //      return CreatedAtAction(nameof(CreateAsync_IActionResult), new { id = product.Id }, product);
        return Created("https://www.example.com/fund/{fundid}", request);
    }
}