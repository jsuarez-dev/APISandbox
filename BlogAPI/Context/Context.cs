
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;

namespace BlogAPI.Context;

public class BlogAPIdBContext : DbContext{

    public BlogAPIdBContext(DbContextOptions<BlogAPIdBContext> options) : base(options){
    }

    public DbSet<Blog> Blogs {set; get;}
}

