namespace Proje.Models;

public class NewsItem
{
    public int Id { get; set; }
    public string? Title { get; set; } 
    public string? SubTitle { get; set; }
    public string? Content { get; set; }
    public string? ImagePath { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}