using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        public string OrderStreamOneID { get; set; }

        public string ListingID { get; set; }

        [ForeignKey("Reseller")]
        public int ResellerID { get; set; }

        [ForeignKey("OrderType")]
        public int OrderTypeID { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        [ForeignKey("OrderStatus")]
        public int OrderStatusID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public virtual ICollection<OrderRow> OrderRows{ get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Reseller Reseller { get; set; }

        public virtual OrderType OrderType { get; set; }

        public virtual OrderStatus OrderStatus { get; set;}

        public Order()
        {
            OrderRows = new HashSet<OrderRow>();
        }

    }
}