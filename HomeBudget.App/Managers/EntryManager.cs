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
        public EntryManager(MenuActionService actionservice)
        {
            _entryService = new EntryService();
            _actionService = actionservice;
        }
        public int AddNewEntry()
        {
            var addEntryMenu1 = _actionService.GetMenuActionsByMenuName("AddEntryMenu1");

            Console.WriteLine("Enter the entry type:");

            for (int i = 0; i < addEntryMenu1.Count; i++)
            {
                Console.WriteLine($"{addEntryMenu1[i].Id}. {addEntryMenu1[i].Name}");
            }

            int typeId;
            var type = Console.ReadKey();
            Int32.TryParse(type.KeyChar.ToString(), out typeId);
            
            var addEntryMenu2 = _actionService.GetMenuActionsByMenuName("AddEntryMenu2");

            Console.WriteLine("Enter the entry category:");

            for (int i = 0; i < addEntryMenu2.Count; i++)
            {
                Console.WriteLine($"{addEntryMenu2[i].Id}. {addEntryMenu2[i].Name}");
            }

            int categoryId;
            var category = Console.ReadKey();
            Int32.TryParse(category.KeyChar.ToString(), out categoryId);

            Console.WriteLine("Please enter date for new entry (in dd/mm/yyyy format):");
            var date = Console.ReadLine();
            DateTime entryDate;
            while (!DateTime.TryParse(date, out entryDate))
            {
                Console.WriteLine("You have entered an incorrect value. Please try again");
                date = Console.ReadLine();
            }

            Console.WriteLine("Please enter amount for new entry:");
            var amount = Console.ReadLine();
            decimal entryAmount;
            Decimal.TryParse(amount, out entryAmount);

            Console.WriteLine("Please enter description for new entry:");
            var entryDescription = Console.ReadLine();

            var lastId = _entryService.GetLastId();
            Entry entry = new Entry(lastId+1, (Entry.typeId)typeId, categoryId, entryDate, entryAmount, entryDescription); 
            _entryService.AddItem(entry);

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
                Console.WriteLine($"Entry category id: {entryToShow.CategoryId}");
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
