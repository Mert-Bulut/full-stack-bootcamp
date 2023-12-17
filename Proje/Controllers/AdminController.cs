using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Proje.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataContext _context;

        public AdminController(DataContext context)
        {
            _context = context;
        }

         public async Task<IActionResult> Index()
        {
            return View(await _context.Kullanicilar.ToListAsync());
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Kullanici");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var kullanici = await _context.Kullanicilar
                                .FirstOrDefaultAsync(u => u.KullaniciId == id);

            if(kullanici == null) 
            {
                return NotFound();
            }

            return View(kullanici);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Kullanici model)
        {
            if(id != model.KullaniciId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!_context.Kullanicilar.Any(u => u.KullaniciId == model.KullaniciId))
                    {
                        return NotFound();
                    } 
                    else 
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var kullanici = await _context.Kullanicilar.FindAsync(id);

            if(kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if(kullanici == null)
            {
                return NotFound();
            }
            _context.Kullanicilar.Remove(kullanici);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
