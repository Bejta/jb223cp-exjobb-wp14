using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class Order
    {

        public int Id { get; set; }

        //public string User_Id { get; set; }

        public string OrderStreamOne_Id { get; set; }

        public string Listing_Id { get; set; }

        //public int Reseller_Id { get; set; }

        //public int OrderType_Id { get; set; }

        //public int OrderStatus_Id { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<OrderRow> OrderRows{ get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Reseller Reseller { get; set; }

        public virtual OrderType OrderType { get; set; }

        public virtual OrderStatus OrderStatus { get; set;}

        public Order()
        {
            OrderRows = new HashSet<OrderRow>();
        }

    }
}