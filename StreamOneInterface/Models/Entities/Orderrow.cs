using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class OrderRow
    {

        public int Id { get; set; }

        //public int OrderRowStatus_Id { get; set; }

        //public string item_id { get; set; }

        //public int Product_Id { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public float UnitPrice { get; set; }

        public virtual Order Order { get; set; }

        public virtual OrderRowStatus OrderRowStatus { get; set; }

        public virtual Product Product { get; set; }

    }
}