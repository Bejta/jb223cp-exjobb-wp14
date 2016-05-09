using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class OrderRowStatus
    {
        public int Id { get; set; }

        public string RowStatus { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }

        public OrderRowStatus()
        {
            OrderRows = new HashSet<OrderRow>();
        }
    }
}