using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Proje.Controllers
{
    public class IletisimController : Controller {
    
        public IActionResult Index()
        {
            return View();
        }
    }
}