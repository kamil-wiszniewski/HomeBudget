using HomeBudget.App.Concrete;
using HomeBudget.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeBudget.App.Managers
{
    public class EntryManager
    {
        private readonly MenuActionService _actionService;
        private EntryService _entryService;
        private CategoryService _categoryService;
        public EntryManager(MenuActionService actionservice, CategoryService categoryService)
        {
            _entryService = new EntryService();
            _categoryService = categoryService;
            _actionService = actionservice;
        }
        public int AddNewEntry()
        {
            var addEntryMenu1 = _actionService.GetMenuActionsByMenuName("AddEntryMenu1");

            Console.Clear();    
            Console.WriteLine("ADD NEW ENTRY");
            Console.WriteLine("\nEnter the entry type:");

            for (int i = 0; i < addEntryMenu1.Count; i++)
            {
                Console.WriteLine($"{addEntryMenu1[i].Id}. {addEntryMenu1[i].Name}");
            }

            int typeId;
            var type = Console.ReadKey();
            Int32.TryParse(type.KeyChar.ToString(), out typeId);
            
            //var addEntryMenu2 = _actionService.GetMenuActionsByMenuName("AddEntryMenu2");
            var categories = _categoryService.GetAllItmes();
            Console.WriteLine("\n\nEnter the entry category:");

            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{categories[i].Id}. {categories[i].Name}");
            }

            int categoryId;
            var chosenCategory = Console.ReadKey();
            Int32.TryParse(chosenCategory.KeyChar.ToString(), out categoryId);
            Category category = new Category(categoryId, categories[categoryId - 1].Name);

            Console.WriteLine("\n\nPlease enter date for new entry (in dd/mm/yyyy format):");
            var date = Console.ReadLine();
            DateTime entryDate;
            while (!DateTime.TryParse(date, out entryDate))
            {
                Console.WriteLine("\nYou have entered an incorrect value. Please try again");
                date = Console.ReadLine();
            }

            Console.WriteLine("\nPlease enter amount for new entry:");
            var amount = Console.ReadLine();
            decimal entryAmount;
            Decimal.TryParse(amount, out entryAmount);

            Console.WriteLine("\nPlease enter description for new entry:");
            var entryDescription = Console.ReadLine();

            var lastId = _entryService.GetLastId();
            Entry entry = new Entry(lastId+1, (Entry.typeId)typeId, category, entryDate, entryAmount, entryDescription); 
            _entryService.AddItem(entry);

            Console.WriteLine("\nNew entry has been added. Press any key to continue...");
            Console.ReadKey();

            return entry.Id;
        }
        public void RemoveEntry()
        {
            var entries = _entryService.GetAllItmes();
            _entryService.ShowAllEntries(entries);

            Console.WriteLine("Please enter the id of the entry you want to remove");
            var idEntered = Console.ReadLine();

            int idToCheck;
            Int32.TryParse(idEntered.ToString(), out idToCheck);    

            bool exists = entries.Any(entry => entry.Id == idToCheck);

            if (exists)
            {
                Entry entryToRemove = entries.FirstOrDefault(e => e.Id == idToCheck);
                Console.WriteLine("Element with ID {0} has been removed.", idToCheck);
                _entryService.RemoveItem(entryToRemove);
            }
            else
            {
                Console.WriteLine("Entry with ID {0} does not exist.", idToCheck);
            }

        }
        public void EntryDetailView()
        {

            var entries = _entryService.GetAllItmes();
            _entryService.ShowAllEntries(entries);

            Console.WriteLine("Please enter the id of the entry you want to see");
            var idEntered = Console.ReadLine();

            int idToCheck;
            Int32.TryParse(idEntered.ToString(), out idToCheck);

            bool exists = entries.Any(entry => entry.Id == idToCheck);

            if (exists)
            {
                Entry entryToShow = entries.FirstOrDefault(e => e.Id == idToCheck);
                Console.WriteLine($"Entry id: {entryToShow.Id}");
                Console.WriteLine($"Entry type id: {entryToShow.TypeId}");
                Console.WriteLine($"Entry category id: {entryToShow.Category.Name}");
                Console.WriteLine($"Entry date: {entryToShow.Date.ToShortDateString()}");
                Console.WriteLine($"Entry amount: {entryToShow.Amount}");
                Console.WriteLine($"Entry description: {entryToShow.Description}");

            }
            else
            {
                Console.WriteLine("Entry with ID {0} does not exist.", idToCheck);
            }
        }
            
    }
}
