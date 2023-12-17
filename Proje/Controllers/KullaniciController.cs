using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Proje.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly DataContext _context;

        public KullaniciController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Profile()
        {
           return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Kullanici");
        }

        [HttpPost]
        public async Task<IActionResult> Index(Kullanici model)
        {
            var kullanici = await _context.Kullanicilar
                                .FirstOrDefaultAsync(u => u.Username == model.Username && u.Sifre == model.Sifre);

            if (kullanici != null)
            {
                var kullaniciId = kullanici.KullaniciId.ToString();
                var kullaniciAdi = kullanici.Username ?? "Bilinmeyen Kullanıcı";
                HttpContext.Session.SetString("KullaniciId", kullaniciId);
                HttpContext.Session.SetString("KullaniciAdi", kullaniciAdi);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kullanici model)
        {
            if (ModelState.IsValid)
            {
                _context.Kullanicilar.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
