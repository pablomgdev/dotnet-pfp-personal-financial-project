using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Base;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class ApiControllerBase : ControllerBase
{
}