using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShopCarts
    {
        private readonly AppDbContext _context;

        public ShopCarts(AppDbContext context)
        {
            this._context = context;
        }
        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        // stex sarqvuma nor sesia erb vor zambyuxi mej arajin angam bana avelanum // ete nor chi avelacvuma
        public static ShopCarts GetShopCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCarts(context) { ShopCartId = shopCartId };
        }


        // shop carti mej avelacnum en korzinayi exace
        public void AddToCart(Car car)
        {
            _context.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });
            _context.SaveChanges();
        }

        // stanum enk shop itemnere
        public List<ShopCartItem> GetShopCartItems()
        {
            return _context.ShopCartItems.Where(s => s.ShopCartId == ShopCartId).Include(c => c.Car).ToList();
        }
    }
}
