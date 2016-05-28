using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [StringLength(100, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string StreamOneNumber { get; set; }

        [Display(Name = "Share Number")]
        [Required(ErrorMessage = "Required field")]
        [StringLength(100, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string ShareNumber { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Required field")]
        [StringLength(100, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Required field")]
        [StringLength(1000, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string Description { get; set; }

        [Display(Name = "Active")]
        [Required(ErrorMessage = "Required field")]
        [DefaultValue(1)]
        public bool Active { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }

        public Product()
        {
            OrderRows = new HashSet<OrderRow>();
        }
    }
}