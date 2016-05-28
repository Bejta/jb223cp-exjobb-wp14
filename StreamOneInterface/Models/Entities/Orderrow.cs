using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required(ErrorMessage = "Required field")]
        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [ForeignKey("OrderRowStatus")]
        [DefaultValue(1)]
        public int OrderRowStatusID { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string ItemID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string StreamOneID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(400, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 4)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Range(0, 1000)]
        [DefaultValue(1)]
        public int Quantity { get; set; }

        [DefaultValue(0.00)]
        public float UnitPrice { get; set; }

        public virtual Order Order { get; set; }

        public virtual OrderRowStatus OrderRowStatus { get; set; }

        public virtual Product Product { get; set; }

    }
}