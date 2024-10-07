using Microsoft.AspNetCore.Mvc;
using BlogAPI.Data;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DemoController : ControllerBase
{
    private readonly ILogger<DemoController> _logger;
    private readonly BlogAPIContext _context;
    private readonly IDemoService _demoService;
    public DemoController(ILogger<DemoController> logger, BlogAPIContext context, IDemoService demoService)
    {
        _logger = logger;
        _context = context;
        _demoService = demoService;
    }

    [HttpGet]
    public ActionResult<String> GetDemo()
    {
        return Ok(_demoService.Hello());
    }

}
