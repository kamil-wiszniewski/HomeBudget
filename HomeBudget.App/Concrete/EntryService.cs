using HomeBudget.App.Common;
using HomeBudget.Domain.Entity;
using HomeBudget.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeBudget.Domain.Entity.Entry;

namespace HomeBudget.App.Concrete
{
    public class EntryService : BaseService<Entry>
    {
        private CategoryService _categoryService;
        public EntryService(CategoryService categoryService)
        {
            _categoryService = categoryService;
            Seed(_categoryService);
        }
        /*public void ShowAllEntries(List<Entry> entries)
        {            
                Console.WriteLine();
                Console.WriteLine("Id\tType\t\tCategory\tDate\t\tAmount\tDescription");
                foreach (var entry in entries)
                {
                    Console.WriteLine($"{entry.Id}\t{entry.TypeId}\t\t{entry.Category.Name}\t\t{entry.Date.ToShortDateString()}\t{entry.Amount}\t{entry.Description}");
                }
        }

        public void ShowFilteredEntries(List<Entry> entries)
        {           
                Console.WriteLine();
                Console.WriteLine("Id\tType\t\tCategory\tDate\t\tAmount\tDescription");
                foreach (var entry in entries)
                {
                    Console.WriteLine($"{entry.Id}\t{entry.TypeId}\t\t{entry.Category.Name}\t\t{entry.Date.ToShortDateString()}\t{entry.Amount}\t{entry.Description}");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
        }*/
        private void Seed(CategoryService categoryService)
        {
            AddItem(new Entry(1, TypeId.Income, categoryService.Items[3], new DateTime(2023, 1, 1), 5000.00m, "salary"));
            AddItem(new Entry(2, TypeId.Expense, categoryService.Items[0], new DateTime(2023, 1, 11), 11.11m,  "grocery"));
            AddItem(new Entry(3, TypeId.Expense, categoryService.Items[1], new DateTime(2023, 1, 15), 65.34m, "medicines"));
            AddItem(new Entry(4, TypeId.Expense, categoryService.Items[0], new DateTime(2023, 1, 23), 57.32m, "grocery"));       
            AddItem(new Entry(5, TypeId.Expense, categoryService.Items[2], new DateTime(2023, 1, 25), 131.17m, "electricity"));
            AddItem(new Entry(6, TypeId.Expense, categoryService.Items[2], new DateTime(2023, 1, 27), 100.50m, "internet"));
            AddItem(new Entry(7, TypeId.Income, categoryService.Items[3], new DateTime(2023, 2, 1), 5000.00m, "salary"));
            AddItem(new Entry(8, TypeId.Expense, categoryService.Items[1], new DateTime(2023, 2, 10), 250.00m, "dentist"));
            AddItem(new Entry(9, TypeId.Expense, categoryService.Items[0], new DateTime(2023, 2, 14), 256.87m, "grocery"));
            AddItem(new Entry(10, TypeId.Expense, categoryService.Items[0], new DateTime(2023, 2, 27), 5.11m, "grocery"));
        }
    }
}
