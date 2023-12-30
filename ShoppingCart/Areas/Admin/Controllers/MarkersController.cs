using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Context;
using ShoppingCart.Models;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MarkersController : Controller
    {
        private readonly AppDbContext _context;

        public MarkersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var markers = await _context.Markers.ToListAsync();
            return View(markers);
        }

        [HttpPost]
        public async Task<IActionResult> AddMarker(string latitude, string longitude, string description)
        {
            var existMarker = await _context.Markers.FirstOrDefaultAsync(x => x.Description == description);
            if (existMarker != null)
            {
                TempData["Error"] = "Пункт выдачи с таким названием уже есть";
                return RedirectToAction("Index", "Products");
            }

            if (ModelState.IsValid)
            {
                var marker = new Marker
                {
                    Latitude = latitude,
                    Longitude = longitude,
                    Description = description
                };

                _context.Markers.Add(marker);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Пункт выдачи успешно добавлен";

                return RedirectToAction("Index", "Products");
            }

            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMarker(int id)
        {
            var marker = await _context.Markers.FindAsync(id);
            if (marker == null)
            {
                TempData["Error"] = "Ошибка при удалении пункта выдачи";
                return RedirectToAction("Index", "Products");
            }

            _context.Markers.Remove(marker);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Пункт выдачи успешно удален";

            return RedirectToAction("Index", "Products");
        }
    }
}
