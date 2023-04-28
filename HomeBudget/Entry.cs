using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget
{
    public class Entry
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }

        public DateTime Date = new DateTime();
        public decimal Amount { get; set; }
        public string Description { get; set; }

    }
}
