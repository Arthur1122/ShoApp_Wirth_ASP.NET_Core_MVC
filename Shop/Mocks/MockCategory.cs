
using Shop.Interfaces.Models;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryName = "ElectroMobile", Desc = "Strong model Auto mobils"},
                    new Category {CategoryName = "Classic Auto mobile", Desc = "Cars with motors of Gas"}
                };
            }
        }
    }
}
