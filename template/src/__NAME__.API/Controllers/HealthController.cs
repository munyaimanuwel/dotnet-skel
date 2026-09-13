using Microsoft.AspNetCore.Mvc;

namespace __NAMESPACE__.API.Controllers;

[ApiController]
[Route("health")]
public sealed class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new { status = "ok", service = "__NAME__" });
}
