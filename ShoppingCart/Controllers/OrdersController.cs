using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Context;
using ShoppingCart.Models;
using ShoppingCart.Models.ViewModels;
using System.Security.Claims;

namespace ShoppingCart.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string pickupPoint)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var cartItems = HttpContext.Session.GetJson<List<CartItem>>($"Cart_{userId}");
            if (cartItems != null)
            {
                foreach (var item in cartItems)
                {
                    var product = await _context.Cars.FindAsync(item.CarId);
                    if (product != null)
                    {
                        product.CountSales += item.Quantity;
                        _context.Update(product);
                    }
                }

                await _context.SaveChangesAsync();
            }

            CartViewModel cartVM = new()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
            };

            var marker = await _context.Markers.FirstOrDefaultAsync(x => x.Description == pickupPoint);

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalPrice = Math.Round(cartVM.GrandTotal, 2),
                MarkerId = marker.Id,
            };

            foreach (var item in cartVM.CartItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    CarId = item.CarId,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove($"Cart_{userId}");

            TempData["Success"] = "Спасибо за покупку!";

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var orders = await _context.Orders
                               .Where(o => o.UserId == userId)
                               .Include(o => o.OrderItems)
                               .ThenInclude(oi => oi.Car)
                               .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var order = await _context.Orders
                                      .Include(o => o.OrderItems)
                                      .ThenInclude(oi => oi.Car)
                                      .Include(o => o.Marker)
                                      .FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
