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

            Console.WriteLine("Enter the entry type");

            for (int i = 0; i < addEntryMenu1.Count; i++)
            {
                Console.WriteLine($"{addEntryMenu1[i].Id}. {addEntryMenu1[i].Name}");
            }
          
            int[] TypeCategory = new int[2];

            Int32.TryParse(Console.ReadKey().ToString(), out TypeCategory[0]);

            
            var addEntryMenu2 = actionService.GetMenuActionsByMenuName("AddEntryMenu2");

            Console.WriteLine("Enter the entry category");

            for (int i = 0; i < addEntryMenu2.Count; i++)
            {
                Console.WriteLine($"{addEntryMenu2[i].Id}. {addEntryMenu2[i].Name}");
            }

            Int32.TryParse(Console.ReadKey().ToString(), out TypeCategory[1]);

            return TypeCategory;
        }

        public void AddNewEntry(int[] typeCategory) 
        {
            Entry entry = new Entry();
            entry.TypeId = typeCategory[0];
            entry.CategoryId = typeCategory[1];

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
           


        }
    }
}
