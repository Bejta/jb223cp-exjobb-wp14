using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class OrderType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Required field")]
        public string Type { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public OrderType()
        {
            Orders = new HashSet<Order>();
        }
    }
}