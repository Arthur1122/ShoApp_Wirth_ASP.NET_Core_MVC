using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategory;

        public CarsController(IAllCars allCars, ICarsCategory allCategory)
        {
            this._allCars = allCars;
            this._allCategory = allCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Page of Cars";

            CarsListViewModel obj = new CarsListViewModel();
            obj.AllCars = _allCars.Cars;
            obj.CurrCategory = "Car";
            return View(obj);
        }
    }
}
