using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string StreamOneNumber { get; set; }

        public string ShareNumber { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<Order> OrderRows { get; set; }

        public Product()
        {
            OrderRows = new HashSet<Order>();
        }
    }
}