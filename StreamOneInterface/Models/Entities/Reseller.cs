using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class Reseller
    {

        public int Id { get; set; }

        [Display(Name = "Customer Number")]
        [Required(ErrorMessage = "Required field")]
        public string CustomerID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Required field")]
        [StringLength(100, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Required field")]
        [StringLength(100, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string Lastname { get; set; }

        [Display(Name = "Address 1")]
        [Required(ErrorMessage = "Required field")]
        [StringLength(100, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Company")]
        [Required(ErrorMessage = "Required field")]
        [StringLength(100, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string Company { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "E-mail address")]
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Required field")]
        [DefaultValue("SE")]
        public string Country { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Zip code")]
        public string Zip { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Reseller()
        {
            Orders = new HashSet<Order>();
        }
    }
}