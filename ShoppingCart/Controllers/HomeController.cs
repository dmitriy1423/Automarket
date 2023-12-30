using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Context;
using ShoppingCart.Models.ViewModels;
using System.Diagnostics;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;


            
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Cars.Where(p => !p.IsDeleted).Where(p => p.CountSales > 0).Count() / pageSize);
            

            var products = await _context.Cars
                                 .Include(p => p.Category)
                                 .Where(p => !p.IsDeleted)
                                 .Where(p => p.CountSales > 0)
                                 .OrderByDescending(p => p.CountSales)
                                 .Skip((p - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();

            return View(products);
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
    }
}