using Api.Controllers.Base;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiVersion("1.0")]
[Produces("application/json")]
public class ExampleController(ILogger<ExampleController> logger) : ApiControllerBase
{
    /// <summary>
    /// This is an endpoint example.
    /// </summary>
    /// <param name="param1">This is an example of parameter.</param>
    /// <returns>Returns nothing.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /Example
    ///     {
    ///        "param1": "example test",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item (just example test)</response>
    /// <response code="400">If the item is null (just example test)</response>
    [ApiVersion("1.0")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetV1(string param1)
    {
        return NoContent();
    }
}