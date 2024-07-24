using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class ExampleController(ILogger<ExampleController> logger) : ControllerBase
{
    [HttpGet]
    [ApiVersion("1.0")]
    public IEnumerable<object> GetV1()
    {
        // TODO: implement this endpoint.
        return new List<object> { new() };
    }
    
    [HttpGet]
    [ApiVersion("2.0")]
    public IEnumerable<object> GetV2()
    {
        // TODO: implement this endpoint.
        return new List<object> { new(), new() };
    }
}