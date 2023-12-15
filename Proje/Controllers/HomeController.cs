using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Data;

namespace Proje.Controllers
{
    public class HomeController : Controller {
        private readonly DataContext _context;
        public HomeController (DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}