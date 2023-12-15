using Microsoft.EntityFrameworkCore;

namespace Proje.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){
            
        }
        public DbSet<Kullanici> Kullanicilar => Set<Kullanici>();
    }
}