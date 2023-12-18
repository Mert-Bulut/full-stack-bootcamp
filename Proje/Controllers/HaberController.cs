using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Data;

namespace Proje.Controllers
{
    public class HaberController : Controller {
        private readonly DataContext _context;
        public HaberController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Asgari()
        {
            return View();
        }
        
        public IActionResult Araba()
        {
            return View();
        }
        public IActionResult Kripto()
        {
            return View();
        }
        public IActionResult Wednesday()
        {
            return View();
        }

        public IActionResult Ftx()
        {
            return View();
        }
        public IActionResult Osym()
        {
            return View();
        }
        public IActionResult SamsungS24()
        {
            return View();
        }
        public IActionResult IstDeprem()
        {
            return View();
        }
    }
}