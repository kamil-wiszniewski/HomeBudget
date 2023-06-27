using HomeBudget.App.Concrete;
using HomeBudget.Domain.Entity;
using HomeBudget.Domain.Helpers;
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
        public EntryManager(MenuActionService actionservice, CategoryService categoryService, EntryService entryService)
        {
            _entryService = entryService;
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

            while (typeId != 1 && typeId != 2)
            {
                Console.WriteLine("\nYou have entered an incorrect value. Please try again");
                type = Console.ReadKey();
                Int32.TryParse(type.KeyChar.ToString(), out typeId);
            }

            var categories = _categoryService.GetAllItmes();
            Console.WriteLine("\n\nEnter the entry category:");

            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{categories[i].Id}. {categories[i].Name}");
            }

            int categoryId;
            var chosenCategory = Console.ReadLine();            

            while (!Int32.TryParse(chosenCategory.ToString(), out categoryId) || categoryId > categories.Count)
            {
                Console.WriteLine("\nYou have entered an incorrect value. Please try again");
                chosenCategory = Console.ReadLine();                
            }

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
            
            while(!Decimal.TryParse(amount, out entryAmount))
            {
                Console.WriteLine("\nYou have entered an incorrect value. Please try again");
                amount = Console.ReadLine();
            }

            Console.WriteLine("\nPlease enter description for new entry:");
            var entryDescription = Console.ReadLine();

            var lastId = _entryService.GetLastId();
            Entry entry = new Entry(lastId+1, (TypeId)typeId, category, entryDate, entryAmount, entryDescription); 
            _entryService.AddItem(entry);

            Console.WriteLine("\nNew entry has been added. Press any key to continue...");
            Console.ReadKey();

            return entry.Id;
        }
        public void RemoveEntry()
        {
            var entries = _entryService.GetAllItmes();

            Console.Clear();
            Console.WriteLine("REMOVE ENTRY");
            Console.WriteLine("\nDo you want to see all entries? (y/n)");
            
            var answer = Console.ReadKey();
            if (answer.KeyChar.ToString() == "y")
            {
                ShowAllEntries(entries);
            }

            Console.WriteLine("\nPlease enter the id of the entry you want to remove");
            var idEntered = Console.ReadLine();

            int idToCheck;
            Int32.TryParse(idEntered.ToString(), out idToCheck);    

            bool exists = entries.Any(entry => entry.Id == idToCheck);

            if (exists)
            {
                Entry entryToRemove = entries.FirstOrDefault(e => e.Id == idToCheck);               
                _entryService.RemoveItem(entryToRemove);
                Console.WriteLine("\nEntry with id {0} has been removed.", idToCheck);
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nEntry with this id does not exist.", idToCheck);
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        public void EntryDetailView()
        {
            var entries = _entryService.GetAllItmes();
            
            Console.Clear();
            Console.WriteLine("ENTRY DETAILS VIEW");
            Console.WriteLine("\nDo you want to see all entries? (y/n)");

            var answer = Console.ReadKey();
            if (answer.KeyChar.ToString() == "y")
            {
                ShowAllEntries(entries);
            }

            Console.WriteLine("\nPlease enter the id of the entry you want to see");
            var idEntered = Console.ReadLine();

            int idToCheck;
            Int32.TryParse(idEntered.ToString(), out idToCheck);

            bool exists = entries.Any(entry => entry.Id == idToCheck);

            if (exists)
            {
                Entry entryToShow = entries.FirstOrDefault(e => e.Id == idToCheck);
                Console.WriteLine(entryToShow.ToString());
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Entry with this id does not exist.", idToCheck);
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        public void SearchEntries()
        {
            var categories = _categoryService.GetAllItmes();
            var entries = _entryService.GetAllItmes();
            List<Entry> filteredEntries = new List<Entry>();
           

            string typeIdFilter = "all";
            string inputCategory = "all";            
            DateTime startDate = entries.Min(e => e.Date);
            DateTime endDate = entries.Max(e => e.Date);
            decimal minAmount = 0;
            decimal maxAmount = entries.Max(e =>e.Amount);

            while (true)
            {
                List<int> searchedCategories = new List<int>();

                Console.Clear();
                Console.WriteLine("SEARCH ENTRIES");
                Console.WriteLine("\nFILTERS");

                if (typeIdFilter == "all")
                {
                    Console.WriteLine("1. Set type filter. Currently set: ALL");
                }
                else
                {
                    int typeIdFilterInt = Int32.Parse(typeIdFilter);
                    Console.WriteLine("1. Set type filter. Currently set: " + (Domain.Helpers.TypeId)typeIdFilterInt);
                }                

                if (inputCategory == "all")
                {
                    searchedCategories = categories.Select(c => c.Id).ToList();
                    Console.WriteLine("2. Set category filter. Currently set: ALL");
                }
                else
                {
                    string[] values = inputCategory.Split(',');
                    foreach (string value in values)
                    {
                        int intValue;
                        if (int.TryParse(value, out intValue))
                        {
                            searchedCategories.Add(intValue);
                        }
                    }

                    Console.Write("2. Set category filter. Currently set: ");
                    foreach (var categoryId in searchedCategories)
                    {
                        var categoryToShow = categories.FirstOrDefault(c => c.Id == categoryId)?.Name;
                        Console.Write(categoryToShow + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("3. Set date filter. Currently set: from " + startDate.ToShortDateString() + " to " + endDate.ToShortDateString());
                Console.WriteLine("4. Set amount filter. Currently set: from " + minAmount + " to " + maxAmount);
                Console.WriteLine("\n5. Search");
                Console.WriteLine("\n0. Exit");

                Console.WriteLine("\nPlease enter what you want to do");
                var operation = Console.ReadKey();

                switch (operation.KeyChar)
                {
                    case '1':
                        Console.WriteLine("\n\nPlease type: \n1 for Income \n2 for Expense or\nall \n\nand then press Enter");
                        var typeInput = Console.ReadLine();
                        if (typeInput == "all")
                        {
                            typeIdFilter = "all";
                        }
                        else
                        {
                            typeIdFilter = typeInput;
                        }

                        break;

                    case '2':
                        CategoryManager category = new CategoryManager(_categoryService, _actionService);
                        category.ShowAllCategories();
                        Console.WriteLine("\nPlease enter category numbers (separated by comma) you want to see and then press Enter. \nOr please enter all and than press Enter");
                        inputCategory = Console.ReadLine();                    

                        break;

                    case '3':
                        Console.WriteLine("\nPlease enter a start date (in dd/mm/yyyy format) \nor press just Enter to set the date of the first entry");                        
                        var date = Console.ReadLine();
                        
                        if (string.IsNullOrWhiteSpace(date)) 
                        {
                            startDate = entries.Min(e => e.Date);
                        }
                        else 
                        {
                            while (!DateTime.TryParse(date, out startDate))
                            {
                                Console.WriteLine("\nYou have entered an incorrect value. Please try again");
                                date = Console.ReadLine();
                            }
                        }
                        
                        Console.WriteLine("\nPlease enter an end date (in dd/mm/yyyy format) \nor press just Enter to set the date of the last entry");
                        var date2 = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(date2))
                        {
                            endDate = entries.Max(e => e.Date);
                        }
                        else
                        {
                            while (!DateTime.TryParse(date2, out endDate))
                            {
                                Console.WriteLine("\nYou have entered an incorrect value. Please try again");
                                date2 = Console.ReadLine();
                            }
                        }

                        break;

                    case '4':
                        Console.WriteLine("\nPlease set minimal amount  \nor press just Enter to set 0");
                        var amount = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(amount))
                        {
                            minAmount = 0;
                        }
                        else
                        {
                            while (!Decimal.TryParse(amount, out minAmount))
                            {
                                Console.WriteLine("\nYou have entered an incorrect value. Please try again");
                                amount = Console.ReadLine();
                            }
                        }

                        Console.WriteLine("\nPlease set maximal amount  \nor press just Enter to set the highest amount of all entries ");
                        var amount2 = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(amount2))
                        {
                            maxAmount = entries.Max(e => e.Amount);
                        }
                        else
                        {
                            while (!Decimal.TryParse(amount2, out maxAmount))
                            {
                                Console.WriteLine("\nYou have entered an incorrect value. Please try again");
                                amount2 = Console.ReadLine();
                            }
                        }

                        break;

                    case '5':
                        if (typeIdFilter == "all")
                        {
                            if (inputCategory == "all")
                            {
                                filteredEntries = entries.Where(e => e.Date >= startDate && e.Date <= endDate &&
                                                                     e.Amount >= minAmount && e.Amount <= maxAmount).ToList();
                                ShowFilteredEntries(filteredEntries);
                            }
                            else
                            {
                                filteredEntries = entries.Where(e => searchedCategories.Contains(e.Category.Id) &&
                                                                e.Date >= startDate && e.Date <= endDate &&
                                                                e.Amount >= minAmount && e.Amount <= maxAmount).ToList();
                                ShowFilteredEntries(filteredEntries);
                            }
                        }
                        else if (typeIdFilter == "1")
                        {
                            if (inputCategory == "all")
                            {
                                filteredEntries = entries.Where(e => e.TypeId == TypeId.Income &&
                                                                     e.Date >= startDate && e.Date <= endDate &&
                                                                     e.Amount >= minAmount && e.Amount <= maxAmount).ToList();
                                ShowFilteredEntries(filteredEntries);
                            }
                            else
                            {
                                filteredEntries = entries.Where(e => searchedCategories.Contains(e.Category.Id) &&
                                                                e.TypeId == TypeId.Income &&
                                                                e.Date >= startDate && e.Date <= endDate &&
                                                                e.Amount >= minAmount && e.Amount <= maxAmount).ToList();
                                ShowFilteredEntries(filteredEntries);
                            }
                        }
                        else
                        {
                            if (inputCategory == "all")
                            {
                                filteredEntries = entries.Where(e => e.TypeId == TypeId.Expense &&
                                                                     e.Date >= startDate && e.Date <= endDate &&
                                                                     e.Amount >= minAmount && e.Amount <= maxAmount).ToList();
                                ShowFilteredEntries(filteredEntries);
                            }
                            else
                            {
                                filteredEntries = entries.Where(e => searchedCategories.Contains(e.Category.Id) &&
                                                                e.TypeId == TypeId.Expense &&
                                                                e.Date >= startDate && e.Date <= endDate &&
                                                                e.Amount >= minAmount && e.Amount <= maxAmount).ToList();
                                ShowFilteredEntries(filteredEntries);
                            }
                        }  
                        
                        break;

                    case '0':
                        return;

                    default:
                        Console.WriteLine("\nAction you entered does not exist");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();  
                        
                        break;
                }
            }
        }

        public void ShowAllEntries(List<Entry> entries)
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
        }
    }
}
