using Microsoft.EntityFrameworkCore;
using Shop.Interfaces.Models;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContext _dbContext;

        public CarRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Car> Cars => _dbContext.Cars.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => _dbContext.Cars.Where(p => p.IsFavorite).Include(c => c.Category);

        public Car GetCar(int carId) => _dbContext.Cars.FirstOrDefault(c => c.Id == carId);
       
    }
}
