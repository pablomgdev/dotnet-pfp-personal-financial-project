using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController(ILogger<ExampleController> logger) : ControllerBase
{
    [HttpGet]
    public IEnumerable<object> Get()
    {
        // TODO: implement this endpoint.
        return new List<object>();
    }
}