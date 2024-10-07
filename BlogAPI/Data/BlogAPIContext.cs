
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;

namespace BlogAPI.Data;

public class BlogAPIContext : DbContext
{

    public BlogAPIContext(DbContextOptions<BlogAPIContext> options) : base(options)
    {
    }

    public DbSet<Blog> Blogs { set; get; } = default!;
}

