using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Context;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string categorySlug = "", int p = 1, string sortOrder = "")
        {
            int pageSize = 4;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.CategorySlug = categorySlug;

            ViewBag.PageTarget = "/products";

            ViewBag.AdditionalQueryParameters = $"&sortOrder={sortOrder}&categorySlug={categorySlug}";

            IQueryable<Car> query = _context.Cars.Include(p => p.Category).Where(p => !p.IsDeleted);

            if (!string.IsNullOrEmpty(categorySlug))
            {
                Category category = await _context.Categories.Where(c => c.Slug == categorySlug).FirstOrDefaultAsync();
                if (category == null) return RedirectToAction("Index");
                query = query.Where(p => p.CategoryId == category.Id);
            }

            switch (sortOrder)
            {
                case "asc":
                    query = query.OrderBy(p => p.Price);
                    break;
                case "desc":
                    query = query.OrderByDescending(p => p.Price);
                    break;
                default:
                    query = query.OrderByDescending(p => p.Id);
                    break;
            }

            ViewBag.TotalPages = (int)Math.Ceiling((decimal)query.Count() / pageSize);
            var products = await query.Skip((p - 1) * pageSize).Take(pageSize).ToListAsync();

            return View(products);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Cars.Include(p => p.Category).Where(p => !p.IsDeleted).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}
