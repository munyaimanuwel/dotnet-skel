using __NAMESPACE__.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace __NAMESPACE__.API.Controllers;

[ApiController]
[Route("api/placeholder")]
public sealed class PlaceholderController : ControllerBase
{
    private readonly IPlaceholderService _service;

    public PlaceholderController(IPlaceholderService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_service.GetPlaceholder());
}
