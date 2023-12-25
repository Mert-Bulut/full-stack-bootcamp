using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje.Models;
using Proje.ViewModels;

namespace Proje.Controllers;
[Authorize(Roles = "Admin Editor")]
public class EditorController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UsersContext _context;

    public EditorController(ILogger<HomeController> logger, UsersContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var newsItems = _context.NewsItems.ToList();
        return View(newsItems);
    }
}