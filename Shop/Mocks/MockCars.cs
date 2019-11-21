using Shop.Interfaces.Models;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Mocks
{
    public class CarsRepository : IAllCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car { Name="Tesla Model S", ShortDesc="Fast car", LongDesc="pretty, fast and very quaiet auto mobile", Img ="/img/tesla.jpg", Price=45000, IsFavorite = true, Available=true, Category=_carsCategory.AllCategories.First() },
                    new Car { Name="Ford Fiesta", ShortDesc="Quiet and relax", LongDesc="Comfortable car for life of city", Img ="/img/fiesta.jpg", Price=20000, IsFavorite = false, Available=true, Category=_carsCategory.AllCategories.Last() },
                    new Car { Name="Toyota Hybrid Range", ShortDesc="Car is econome", LongDesc="Comfortable car for driving long away", Img ="/img/toyota.jpg", Price=25000, IsFavorite = true, Available=true, Category=_carsCategory.AllCategories.First() },
                    new Car { Name="BMW X7", ShortDesc="Very fast car", LongDesc="Type of car is sport and relax", Img ="/img/BMW.jpg", Price=65000, IsFavorite = false, Available=true, Category=_carsCategory.AllCategories.Last() },


                };
            }
        }
        public IEnumerable<Car> GetFavCars { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Car GetCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
