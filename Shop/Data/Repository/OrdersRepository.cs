using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContext _context;
        private readonly ShopCarts _shopCarts;
        public OrdersRepository(AppDbContext context, ShopCarts shopCarts)
        {
            this._context = context;
            this._shopCarts = shopCarts;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _context.Orders.Add(order);

            var items = _shopCarts.ListShopItems;

            foreach (var el in items)
            {
                var orderDet = new OrderDetail()
                {
                    CarId = el.Car.Id,
                    Price = el.Car.Price,
                    OrderId = order.Id
                };

                _context.OrderDetails.Add(orderDet);
            }

            _context.SaveChanges();
        }
    }
}
