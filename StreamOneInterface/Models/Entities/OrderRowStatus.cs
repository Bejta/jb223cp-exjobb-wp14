using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class OrderRowStatus
    {
        [Key]
        [Display(Name = "Item Status ID")]
        //[Required(ErrorMessage = "Required field")]
        public int Id { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Required field")]
        public string RowStatus { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }

        public OrderRowStatus()
        {
            OrderRows = new HashSet<OrderRow>();
        }
    }
}