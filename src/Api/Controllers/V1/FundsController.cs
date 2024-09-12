using Api.Controllers.Base;
using Api.Mappers;
using Application.Funds.Create;
using Asp.Versioning;
using Contracts.Funds;
using Domain.Funds.Services;
using Microsoft.AspNetCore.Mvc;
using Fund = Domain.Funds.Models.Fund;

namespace Api.Controllers.V1;

[ApiVersion("1.0")]
public class FundsController(
    FundsCreator fundsCreator,
    FundFinder fundFinder
) : JsonApiControllerBase
{
    /// <summary>
    ///     Creates a new fund.
    /// </summary>
    /// <param name="request">Fund data.</param>
    /// <returns>Returns the fund already created.</returns>
    /// <response code="201">Fund created successfully.</response>
    /// <response code="500">Internal server error.</response>
    [MapToApiVersion("1.0")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CreateFundResponse>> Create([FromBody] CreateFundRequest request)
    {
        // TODO: move all this logic (see if already exists and create) to the Application/Domain level so it can be
        //  tested by a unit test.

        var fundId = request.Id;

        Fund fundFound = null;
        if (fundId.HasValue) fundFound = await fundFinder.Find(fundId.Value);

        // TODO: see if errors must be standardized.
        if (fundFound is not null) return StatusCode(409, $"fund {fundFound.Id.Value} already exists");

        var fundCreated = await fundsCreator.Create(fundId, request.Name, request.Description);

        var responseData = fundCreated.MapToDto();
        return CreatedAtAction(nameof(Create), new { fundId = fundCreated.Id }, responseData);
    }
}