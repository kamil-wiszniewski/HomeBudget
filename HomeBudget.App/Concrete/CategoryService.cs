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

        private void Initialize()
        {
            AddItem(new Category(1, "food"));
            AddItem(new Category(2, "health"));
            AddItem(new Category(3, "bills"));
            AddItem(new Category(4, "salary"));
        }
    }
}
