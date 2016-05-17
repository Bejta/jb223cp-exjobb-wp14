using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Stream One Number")]
        [Required(ErrorMessage = "Required field")]
        public string StreamOneNumber { get; set; }

        [Display(Name = "Share Number")]
        [Required(ErrorMessage = "Required field")]
        public string ShareNumber { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Required field")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }

        [Display(Name = "Active")]
        [Required(ErrorMessage = "Required field")]
        public bool Active { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }

        public Product()
        {
            OrderRows = new HashSet<OrderRow>();
        }
    }
}