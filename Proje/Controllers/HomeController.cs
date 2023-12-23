using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proje.Models;
using Proje.ViewModels;

namespace Proje.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NewsContext _context;

    public HomeController(ILogger<HomeController> logger, NewsContext context)
{
    _logger = logger;
    _context = context;
}

    public IActionResult Index()
    {
        var newsItems = _context.NewsItems.ToList();
        return View(newsItems);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNewsViewModel model)
    {
        if (ModelState.IsValid)
        {
            var newsItem = new NewsItem
            {
                Title = model.haberBasligi,
                SubTitle = model.haberAltBasligi,
                Content = model.haberIcerigi,
                // ImagePath burada dosya yükleme işlemini de ele almalısınız
                CreatedAt = DateTime.UtcNow
            };
            _context.NewsItems.Add(newsItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index"); // veya başarılı kayıttan sonra gitmek istediğiniz view
        }
        return View(model); // Eğer model geçersizse, formu hatalarla birlikte geri göster
    }
}
