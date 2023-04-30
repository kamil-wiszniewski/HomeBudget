using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget
{
    public class EntryService
    {
        public List<Entry> Entries { get; set; }

        public EntryService()
        {
            Entries = new List<Entry>();
        }

        public int[] AddNewEntryView(MenuActionService actionService)
        {
            var addEntryMenu1 = actionService.GetMenuActionsByMenuName("AddEntryMenu1");

            Console.WriteLine("Enter the entry type:");

            for (int i = 0; i < addEntryMenu1.Count; i++)
            {
                Console.WriteLine($"{addEntryMenu1[i].Id}. {addEntryMenu1[i].Name}");
            }

            int[] typeCategory = new int[2];

            //var type = Console.ReadKey();
            Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out typeCategory[0]);
         
            var addEntryMenu2 = actionService.GetMenuActionsByMenuName("AddEntryMenu2");

            Console.WriteLine("Enter the entry category");

            for (int i = 0; i < addEntryMenu2.Count; i++)
            {
                Console.WriteLine($"{addEntryMenu2[i].Id}. {addEntryMenu2[i].Name}");
            }

            var category = Console.ReadKey();
            Int32.TryParse(category.KeyChar.ToString(), out typeCategory[1]);
         
            return typeCategory;
        }

        public int AddNewEntry(int[] typeCategory)
        {
            Entry entry = new Entry();

            Console.WriteLine("Please enter id for new entry:");
            var id = Console.ReadLine();
            int entryId;
            Int32.TryParse(id, out entryId);

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

            entry.TypeId = typeCategory[0];
            entry.CategoryId = typeCategory[1];
            entry.Id = entryId;
            entry.Date = entryDate;
            entry.Amount = entryAmount;
            entry.Description = entryDescription;

            Entries.Add(entry);

            return entryId;
        }

        public int RemoveEntryView()
        {
            Console.WriteLine("Please enter id for entry you want to remove:");
            var entryId = Console.ReadKey();
            int id;
            Int32.TryParse(entryId.KeyChar.ToString(), out id);

            return id;
        }

        public void RemoveEntry(int removeId)
        {
            Entry entryToRemove = new Entry();

            foreach (var entry in Entries) 
            {
                if(entry.Id == removeId)
                {
                    entryToRemove = entry;
                    break;
                }
            }
            Entries.Remove(entryToRemove);
        }

        public int EntryDetailSelectionView()
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
    }
}
