using HomeBudget.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.Domain.Entity;

namespace HomeBudget.App.Concrete
{
    public class EntryService : BaseService<Entry>
    {
        public void ShowAllEntries(List<Entry> entries)
        {
            Console.WriteLine("Do you want to see all entries? (y/n)");
            var answer = Console.ReadKey();

            if (answer.KeyChar.ToString() == "y")
            {
                Console.WriteLine();
                Console.WriteLine("Id\tType Id\t\tCategory Id\tDate\t\tAmount\tDescription");
                foreach (var entry in entries)
                {
                    Console.WriteLine($"{entry.Id}\t{entry.TypeId}\t\t{entry.CategoryId}\t\t{entry.Date.ToShortDateString()}\t{entry.Amount}\t{entry.Description}");
                }
            }                    

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
