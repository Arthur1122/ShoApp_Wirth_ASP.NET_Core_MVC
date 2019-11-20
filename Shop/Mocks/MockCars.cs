using Shop.Interfaces.Models;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car { Name="Tesla Model S", ShortDesc="Fast car", LongDesc="pretty, fast and very quaiet auto mobile", Img ="https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/tesla-model-s-1563301327.jpg?crop=0.627xw:1.00xh;0.0929xw,0&resize=768:*", Price=45000, IsFavorite = true, Available=true, Category=_carsCategory.AllCategories.First() },
                    new Car { Name="Ford Fiesta", ShortDesc="Quiet and relax", LongDesc="Comfortable car for life of city", Img ="https://di-uploads-pod14.dealerinspire.com/kingsford/uploads/2018/02/ford_fiesta2018_grey.jpg", Price=20000, IsFavorite = false, Available=true, Category=_carsCategory.AllCategories.Last() },
                    new Car { Name="Toyota Hybrid Range", ShortDesc="Car is econome", LongDesc="Comfortable car for driving long away", Img ="https://cdn.images.express.co.uk/img/dynamic/24/590x/Toyota-Prius-1027142.jpg?r=1538721243798", Price=25000, IsFavorite = true, Available=true, Category=_carsCategory.AllCategories.First() },
                    new Car { Name="BMW X7", ShortDesc="Very fast car", LongDesc="Type of car is sport and relax", Img ="https://robbreportedit.files.wordpress.com/2018/10/bmw-x7-6.jpg?w=660", Price=65000, IsFavorite = false, Available=true, Category=_carsCategory.AllCategories.Last() },


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
