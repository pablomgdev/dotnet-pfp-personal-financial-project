using Api.Controllers.Base;
using Api.Mappers;
using Application.Funds.Create;
using Asp.Versioning;
using Contracts.Funds;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiVersion("1.0")]
public class FundsController(
    FundsCreator fundsCreator
) : JsonApiControllerBase
{
    // TODO: <br /> does not work in swagger. Fix it.
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
    public async Task<ActionResult<CreateFundResponse>> Create([FromBody] CreateFundRequest request)
    {
        var fundCreated = await fundsCreator.Create(request.Id, request.Name, request.Description);
        var responseData = fundCreated.MapToDto();
        return CreatedAtAction(nameof(Create), new { fundId = fundCreated.Id }, responseData);
    }
}