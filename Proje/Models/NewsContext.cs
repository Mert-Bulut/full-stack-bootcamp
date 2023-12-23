using Microsoft.EntityFrameworkCore;
namespace Proje.Models;

public class NewsContext : DbContext
{
    public NewsContext(DbContextOptions<NewsContext> options) : base(options)
    {
    }

    public DbSet<NewsItem> NewsItems { get; set; }
}