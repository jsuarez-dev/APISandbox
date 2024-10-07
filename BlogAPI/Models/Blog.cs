
namespace BlogAPI.Models;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
    public DateTime PublishAt { get; set; } = DateTime.Now;
    public bool Publish { get; set; } = false;
}
