using HomeBudget.Domain.Common;
using HomeBudget.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace HomeBudget.Domain.Entity
{
    public class Entry : BaseEntity
    {       
        public TypeId TypeId { get; set; }        
        public Category Category { get; set; }
        public DateTime Date { get; set; }       
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public Entry()
        {            
        }
        public Entry(int id, TypeId typeId, Category category, DateTime date, decimal amount, string description)
        {
            Id = id;
            TypeId = typeId;
            Category = category;
            Date = date;
            Amount = amount;
            Description = description;
        }

        public override string ToString()
        {
            return $"\nENTRY DETAILS: \nid: {Id}\ntypeId: {TypeId}\ncategory: {Category.Name}\ndate: {Date.ToShortDateString()}\namount: {Amount}\ndescription: {Description}";
        }            
    }
}
