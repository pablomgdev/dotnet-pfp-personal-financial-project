using Api.Controllers.Base;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V2;

[ApiVersion("2.0")]
public class ExampleController(ILogger<ExampleController> logger) : ApiControllerBase
{
    [ApiVersion("2.0")]
    //[MapToApiVersion("2.0")]
    [HttpGet]
    public IEnumerable<object> GetV2()
    {
        return new List<object> { new(), new() };
    }
}