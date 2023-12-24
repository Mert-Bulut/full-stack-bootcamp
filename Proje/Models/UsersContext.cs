using Microsoft.EntityFrameworkCore;
namespace Proje.Models;

public class UsersContext : DbContext
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
    }

    public DbSet<NewsItem> NewsItems { get; set; }
    public DbSet<IletisimFormu> IletisimFormlari { get; set; }
}