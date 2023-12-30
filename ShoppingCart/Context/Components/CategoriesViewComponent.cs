using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Context.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public CategoriesViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categorySlug)
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.CurrentCategorySlug = categorySlug;
            return View(categories);
        }
    }
}
