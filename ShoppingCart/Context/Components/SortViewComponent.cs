﻿using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Context.Components
{
    public class SortViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public SortViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View();
    }
}
