using Microsoft.AspNetCore.Mvc;
using BlogAPI.Data;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LifeTimeController : ControllerBase
{
    private readonly ILogger<LifeTimeController> _logger;
    private readonly BlogAPIContext _context;
    private readonly IScopeService _scopeService;
    private readonly ISingService _singService;
    private readonly ITranService _tranService;
    public LifeTimeController(
        ILogger<LifeTimeController> logger,
        BlogAPIContext context,
        ITranService tranService,
        ISingService singService,
        IScopeService scopeService
        )
    {
        _logger = logger;
        _context = context;
        _singService = singService;
        _tranService = tranService;
        _scopeService = scopeService;
    }

    [HttpGet]
    public ActionResult<String> GetDemo()
    {
        string responce = $"""
        {_scopeService.SayHello()}
        **************************
        {_tranService.SayHello()}
        **************************
        {_singService.SayHello()}
        **************************
        """;
        string responce2 = $"""
        {_scopeService.SayHello()}
        **************************
        {_tranService.SayHello()}
        **************************
        {_singService.SayHello()}
        **************************
        """;
        return Ok($"{responce}\n\n=================\n\n{responce2}");
    }

}
