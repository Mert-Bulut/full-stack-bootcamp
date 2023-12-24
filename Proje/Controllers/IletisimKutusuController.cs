using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Models;

namespace Proje.Controllers
{
    public class IletisimKutusuController : Controller 
    {
        private readonly UsersContext _context;

        public IletisimKutusuController(UsersContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var iletisimFormlari = await _context.IletisimFormlari.ToListAsync();
            return View(iletisimFormlari);
        }
    }
}