using Microsoft.EntityFrameworkCore;
using Proje.Data;

var builder = WebApplication.CreateBuilder(args);

// MVC Controller desteği
builder.Services.AddControllersWithViews();

// IHttpContextAccessor servisini ekleme
builder.Services.AddHttpContextAccessor();

// Veritabanı bağlantısı
builder.Services.AddDbContext<DataContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("data");
    options.UseSqlite(connectionString);
});

// Oturum desteği
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Uygulama yapılandırması
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
