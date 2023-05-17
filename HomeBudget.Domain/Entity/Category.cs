using HomeBudget.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Domain.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;          
        }

    }
}
