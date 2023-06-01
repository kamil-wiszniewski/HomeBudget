using HomeBudget.App.Common;
using HomeBudget.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.App.Concrete
{
    public class CategoryService : BaseService<Category>
    {
        public CategoryService()
        {
            Initialize();
        }
        public void ShowAllCategories(List<Category> categories)
        {                      
                Console.WriteLine();
                Console.WriteLine("Id\tName");
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id}\t{category.Name}");
                }
        }

        private void Initialize()
        {
            AddItem(new Category(1, "food"));
            AddItem(new Category(2, "health"));
            AddItem(new Category(3, "bills"));
            AddItem(new Category(4, "salary"));
        }
    }
}
