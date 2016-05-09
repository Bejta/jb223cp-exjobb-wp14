using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class OrderType
    {

        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public OrderType()
        {
            Orders = new HashSet<Order>();
        }
    }
}