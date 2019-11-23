using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces.Models;
using Shop.Models;
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

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";

            if(string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("ElectroMobile")).OrderBy(i => i.Id);
                    currCategory = "Electro Auto mobiles";
                }
                else if(string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Classic Auto mobile")).OrderBy(i => i.Id);
                    currCategory = "Classic Auto mobiles";
                }

            }
                var carObj = new CarsListViewModel()
                {
                    AllCars = cars,
                    CurrCategory = currCategory
                };

            ViewBag.Title = "Page of Cars";

            
            return View(carObj);
            
        }
    }
}
