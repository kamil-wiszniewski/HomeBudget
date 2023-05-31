using HomeBudget.App.Concrete;
using HomeBudget.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeBudget.Domain.Entity.Entry;

namespace HomeBudget.App.Managers
{
    public class CategoryManager
    {
        private CategoryService _categoryService;
        private readonly MenuActionService _actionService;
        public CategoryManager(CategoryService categoryService, MenuActionService actionService)
        {
            _categoryService = categoryService;
            _actionService = actionService;
        }

        public void ManageCategories()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("MANAGE CATEGORIES");
                Console.WriteLine("\nPlease let me know what you want to do:");

                var categoryMenu = _actionService.GetMenuActionsByMenuName("ManageCategories");
                var categories = _categoryService.GetAllItmes();

                for (int i = 0; i < categoryMenu.Count; i++)
                {
                    Console.WriteLine($"{categoryMenu[i].Id}. {categoryMenu[i].Name}");
                }
                Console.WriteLine("\n0. Exit");

                var operation = Console.ReadKey();

                switch (operation.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("SHOW ALL CATEGORIES");
                        _categoryService.ShowAllCategories(categories);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case '2':
                        Console.WriteLine("\nDo you want to see all categories? (y/n)");
                        var answer = Console.ReadKey();

                        if (answer.KeyChar.ToString() == "y")
                        {
                            _categoryService.ShowAllCategories(categories);
                        }

                        Console.WriteLine("\nPlease enter name for new category:");
                        var categoryName = Console.ReadLine();

                        bool exists = categories.Any(category => category.Name == categoryName);

                        if (exists)
                        {
                            Console.WriteLine("Category with name {0} already exists.", categoryName);
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            var lastId = _categoryService.GetLastId();
                            Category category = new Category(lastId + 1, categoryName);
                            _categoryService.AddItem(category);

                            Console.WriteLine($"\nCategory {category.Name} has been added. Press any key to continue...");
                            Console.ReadKey();
                        }

                        break;

                    case '3':
                        RemoveCategory();
                        break;

                    case '0':
                        return;

                    default:
                        Console.WriteLine("Action you entered does not exist");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void RemoveCategory()
        {
            var categories = _categoryService.GetAllItmes();
            Console.WriteLine("\nDo you want to see all categories? (y/n)");
            var answer2 = Console.ReadKey();

            if (answer2.KeyChar.ToString() == "y")
            {
                _categoryService.ShowAllCategories(categories);
            }

            Console.WriteLine("Please enter the id of the category you want to remove");
            var idEntered = Console.ReadLine();

            int idToCheck;
            Int32.TryParse(idEntered.ToString(), out idToCheck);

            bool exists = categories.Any(entry => entry.Id == idToCheck);

            if (exists)
            {
                Category categoryToRemove = categories.FirstOrDefault(e => e.Id == idToCheck);
                _categoryService.RemoveItem(categoryToRemove);
                Console.WriteLine("Category with id {0} has been removed.", idToCheck);
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();                
            }
            else
            {
                Console.WriteLine("Category with this id does not exist.", idToCheck);
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        
    }
}
