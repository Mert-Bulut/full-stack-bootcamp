using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Models;

namespace Proje.Controllers
{
    public class IletisimController : Controller {

        private readonly UsersContext _context;

        public IletisimController(UsersContext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IletisimFormu model)
        {
            if(ModelState.IsValid)
            {
                _context.IletisimFormlari.Add(model);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Mesajınız başarıyla gönderildi!";
                return View();
            }
            return View(model);
        }
    }
}