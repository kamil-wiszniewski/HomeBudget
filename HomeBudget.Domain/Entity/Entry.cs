using HomeBudget.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Domain.Entity
{
    public class Entry : BaseEntity
    {
        public enum typeId
        {
            Income = 1,
            Expense
        }
        public typeId TypeId { get; set; }
        //public int TypeId { get; set; }
        //public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
        //public DateTime Date = new DateTime();
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public Entry()
        {
            
        }
        public Entry(int id, typeId typeId, Category category, DateTime date, decimal amount, string description)
        {
            Id = id;
            TypeId = typeId;
            Category = category;
            Date = date;
            Amount = amount;
            Description = description;
        }

    }
}
