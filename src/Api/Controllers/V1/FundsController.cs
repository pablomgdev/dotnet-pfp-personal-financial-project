using Api.Controllers.Base;
using Api.Mappers;
using Application.Funds;
using Asp.Versioning;
using Contracts.Funds;
using Domain.Funds.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiVersion("1.0")]
public class FundsController(
    FundsCreator fundsCreator
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
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CreateFundResponse>> Create([FromBody] CreateFundRequest request)
    {
        // TODO: create a middleware to handle errors.
        try
        {
            var fundCreated = await fundsCreator.Execute(request.Id, request.Name, request.Description);
            var responseData = fundCreated.MapToDto();
            return CreatedAtAction(nameof(Create), new { fundId = fundCreated.Id }, responseData);
        }
        catch (FundAlreadyExistsException e)
        {
            // Standardized responses (error responses).
            return StatusCode(409, e.Message);
        }
    }
}