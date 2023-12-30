using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Context;
using ShoppingCart.Models;
using ShoppingCart.Models.ViewModels;
using System.Security.Claims;

namespace ShoppingCart.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public IActionResult Index()
        {
            string userId = GetUserId();
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>($"Cart_{userId}") ?? new List<CartItem>();

            var pickupPoints = _context.Markers.Select(m => m.Description).ToList();
            ViewBag.PickupPoints = new SelectList(pickupPoints);

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            return View(cartVM);
        }

        public async Task<IActionResult> Add(int id)
        {
            Car product = await _context.Cars.FindAsync(id);

            string userId = GetUserId();
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>($"Cart_{userId}") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.CarId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson($"Cart_{userId}", cart);

            TempData["Success"] = "Товар был успешно добавлен в корзину";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(int id)
        {
            Car product = await _context.Cars.FindAsync(id);

            string userId = GetUserId();
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>($"Cart_{userId}");

            CartItem cartItem = cart.Where(c => c.CarId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.CarId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove($"Cart_{userId}");
            }
            else
            {
                HttpContext.Session.SetJson($"Cart_{userId}", cart);
            }

            TempData["Success"] = "Товар был успешно удален";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            string userId = GetUserId();
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>($"Cart_{userId}");

            cart.RemoveAll(p => p.CarId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove($"Cart_{userId}");
            }
            else
            {
                HttpContext.Session.SetJson($"Cart_{userId}", cart);
            }

            TempData["Success"] = "Товар был успешно удален";

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            string userId = GetUserId();
            HttpContext.Session.Remove($"Cart_{userId}");

            return RedirectToAction("Index");
        }
    }
}
