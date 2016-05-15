using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class OrderRow
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [ForeignKey("OrderRowStatus")]
        public int OrderRowStatusID { get; set; }

        //[ForeignKey("Product")]
        public string ItemID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public float UnitPrice { get; set; }

        public virtual Order Order { get; set; }

        public virtual OrderRowStatus OrderRowStatus { get; set; }

        public virtual Product Product { get; set; }

    }
}