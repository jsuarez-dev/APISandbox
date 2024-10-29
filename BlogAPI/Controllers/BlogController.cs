using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Models;
using BlogAPI.Data;

namespace BlogAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly ILogger<BlogController> _logger;
    private readonly BlogAPIContext _context;
    public BlogController(ILogger<BlogController> logger, BlogAPIContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Blog>> GetAllBlog()
    {
        var Blogs = _context.Blogs.ToList();
        return Ok(Blogs);
    }

    [HttpGet("{id}")]
    public ActionResult<Blog> GetBlog(int id)
    {
        var Blog = _context.Blogs.Where(x => x.Id == id).ToList();
        if (Blog.Count == 0)
        {
            return NotFound();
        }
        return Ok(Blog);
    }

    [HttpPost]
    public async Task<ActionResult<Blog>> CreateBlog(Blog blog)
    {
        await _context.Blogs.AddAsync(blog);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, blog);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Blog>> UpdateBlog(int id,[FromForm] string title, [FromForm] string content) 
    {
        var Blog = _context.Blogs.FirstOrDefault(x => x.Id == id);
        if (Blog == null)
        {
            return NotFound();
        }
        Blog.Title = title;
        Blog.Content = content;
        _context.Entry(Blog);
        await _context.SaveChangesAsync();
        return Ok(Blog);

    }
}
