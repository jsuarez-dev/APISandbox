using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly ILogger<PostsController> _logger;
    public PostsController(ILogger<PostsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public String GetAllPosts()
    {
        return "Local";
    }

    [HttpGet("{id}")]
    public String GetPost(int id)
    {
        return $"Post {id}";
    }
}
