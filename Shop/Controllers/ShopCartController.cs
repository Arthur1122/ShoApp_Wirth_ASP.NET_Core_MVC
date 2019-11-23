using Microsoft.AspNetCore.Mvc;
using Shop.Data.Repository;
using Shop.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;
using Shop.ViewModels;
using Shop.Interfaces.Models;

namespace Shop.Controllers
{
    public class ShopCartController :Controller
    {
        private readonly IAllCars _carRepository;
        private readonly ShopCarts _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCarts shopCart)
        {
            this._carRepository = carRepository;
            this._shopCart = shopCart;
        }
        
        public ActionResult Index()
        {
            var items = _shopCart.GetShopCartItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                ShopCarts = _shopCart
            };
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _carRepository.Cars.FirstOrDefault(i => i.Id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
