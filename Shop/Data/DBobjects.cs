using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBobjects
    {
        public static void Initial(AppDbContext content)
        {
            if (!content.Categories.Any())
            {
                content.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if(!content.Cars.Any())
            {
                content.AddRange(
                    new Car { Name = "Tesla Model S", ShortDesc = "Fast car", LongDesc = "pretty, fast and very quaiet auto mobile", Img = "/img/tesla.jpg", Price = 45000, IsFavorite = true, Available = true, Category = Categories["ElectroMobile"] },
                    new Car { Name = "Ford Fiesta", ShortDesc = "Quiet and relax", LongDesc = "Comfortable car for life of city", Img = "/img/fiesta.jpg", Price = 20000, IsFavorite = false, Available = true, Category = Categories["Classic Auto mobile"] },
                    new Car { Name = "Toyota Hybrid Range", ShortDesc = "Car is econome", LongDesc = "Comfortable car for driving long away", Img = "/img/toyota.jpg", Price = 25000, IsFavorite = true, Available = true, Category = Categories["ElectroMobile"] },
                    new Car { Name = "BMW X7", ShortDesc = "Very fast car", LongDesc = "Type of car is sport and relax", Img = "/img/BMW.jpg", Price = 65000, IsFavorite = false, Available = true, Category = Categories["Classic Auto mobile"] }

                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "ElectroMobile", Desc = "Strong model Auto mobils"},
                        new Category {CategoryName = "Classic Auto mobile", Desc = "Cars with motors of Gas"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category item in list)
                    {
                        category.Add(item.CategoryName, item);
                    }
                }
                return category;
            }
        }
    }
}
