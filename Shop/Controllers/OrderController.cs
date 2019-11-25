using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCarts _shopCart;

        public OrderController( IAllOrders allOrders, ShopCarts shopCart)
        {
            this._allOrders = allOrders;
            this._shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopCartItems();

            if(_shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "You have to take products");
            }

            if(ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }


            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order successfuly send";
            return View();
        }
    }
}
