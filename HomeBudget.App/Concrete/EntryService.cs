using HomeBudget.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.Domain.Entity;
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
        public void ShowAllEntries(List<Entry> entries)
        {
            //Console.WriteLine("Do you want to see all entries? (y/n)");
            //var answer = Console.ReadKey();

            //if (answer.KeyChar.ToString() == "y")
            //{
                Console.WriteLine();
                Console.WriteLine("Id\tType\t\tCategory\tDate\t\tAmount\tDescription");
                foreach (var entry in entries)
                {
                    Console.WriteLine($"{entry.Id}\t{entry.TypeId}\t\t{entry.Category.Name}\t\t{entry.Date.ToShortDateString()}\t{entry.Amount}\t{entry.Description}");
                }
           // }                    

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
        }
        private void Seed(CategoryService categoryService)
        {
            AddItem(new Entry(1, typeId.Income, categoryService.Items[3], new DateTime(2023, 1, 1), 5000.00m, "salary"));
            AddItem(new Entry(2, typeId.Expense, categoryService.Items[0], new DateTime(2023, 1, 11), 11.11m,  "grocery"));
            AddItem(new Entry(3, typeId.Expense, categoryService.Items[1], new DateTime(2023, 1, 15), 65.34m, "medicines"));
            AddItem(new Entry(4, typeId.Expense, categoryService.Items[0], new DateTime(2023, 1, 23), 57.32m, "grocery"));       
            AddItem(new Entry(5, typeId.Expense, categoryService.Items[2], new DateTime(2023, 1, 25), 131.17m, "electricity"));
            AddItem(new Entry(6, typeId.Expense, categoryService.Items[2], new DateTime(2023, 1, 27), 100.50m, "internet"));
            AddItem(new Entry(7, typeId.Income, categoryService.Items[3], new DateTime(2023, 2, 1), 5000.00m, "salary"));
            AddItem(new Entry(8, typeId.Expense, categoryService.Items[1], new DateTime(2023, 2, 10), 250.00m, "dentist"));
            AddItem(new Entry(9, typeId.Expense, categoryService.Items[0], new DateTime(2023, 2, 14), 256.87m, "grocery"));
            AddItem(new Entry(10, typeId.Expense, categoryService.Items[0], new DateTime(2023, 2, 27), 5.11m, "grocery"));
        }

        





        /*public int EntryDetailSelectionView()
        {
            Console.WriteLine("Please enter id for entry you want to show:");
            var detailId = Console.ReadKey();
            int id;
            Int32.TryParse(detailId.KeyChar.ToString(), out id);

            return id;
        }

        public void EntryDetailView(int detailId)
        {
            Entry entryToShow = new Entry();

            foreach (var entry in Entries)
            {
                if (entry.Id == detailId)
                {
                    entryToShow = entry;
                    break;
                }
            }
            Console.WriteLine($"Entry id: {entryToShow.Id}");
            Console.WriteLine($"Entry type id: {entryToShow.TypeId}");
            Console.WriteLine($"Entry category id: {entryToShow.CategoryId}");
            Console.WriteLine($"Entry date: {entryToShow.Date}");
            Console.WriteLine($"Entry amount: {entryToShow.Amount}");
            Console.WriteLine($"Entry description: {entryToShow.Description}");
        }

        public int EntryTypeSelectionView()
        {
            Console.WriteLine("Please enter Type id for entry type you want to show:");
            var typeId = Console.ReadKey();
            int id;
            Int32.TryParse(typeId.KeyChar.ToString(), out id);

            return id;
        }

        public void EntriesByTypeIdView(int typeId)
        {
            List<Entry> toShow = new List<Entry>();

            foreach (var entry in Entries)
            {
                if (entry.TypeId == typeId)
                {
                    toShow.Add(entry);
                }
            }

            for (int i = 0; i < toShow.Count; i++)
            {
                Console.WriteLine($"lp. {i + 1} id: {toShow[i].Id} type id: {toShow[i].TypeId} category id: {toShow[i].CategoryId} date: {toShow[i].Date} amount: {toShow[i].Amount} description: {toShow[i].Description}");
            }
        }*/
    }
}
