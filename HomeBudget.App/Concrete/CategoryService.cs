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
        
        public bool IfExists(int idToCheck) 
        {
            var categories = GetAllItmes();
            if(categories.Any(category => category.Id == idToCheck)) 
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        public Category CategoryToRemove(int idToCheck) 
        {
            var categories = GetAllItmes();
            var categoryToRemove = categories.First(c => c.Id == idToCheck);
            return categoryToRemove;
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
