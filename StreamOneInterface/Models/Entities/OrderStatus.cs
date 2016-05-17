using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class OrderStatus
    {
        [Display(Name = "Status ID")]
        //[Required(ErrorMessage = "Required field")]
        public int Id { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Required field")]
        public string Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }
    }
}