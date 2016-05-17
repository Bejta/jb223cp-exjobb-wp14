using System;
using System.Collections.Generic;
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
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Required field")]
        public string Lastname { get; set; }

        [Display(Name = "Address 1")]
        [Required(ErrorMessage = "Required field")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        [Required(ErrorMessage = "Required field")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Required field")]
        public string City { get; set; }

        [Display(Name = "Company")]
        [Required(ErrorMessage = "Required field")]
        public string Company { get; set; }

        [Display(Name = "Website")]
        [Required(ErrorMessage = "Required field")]
        public string Website { get; set; }

        [Display(Name = "E-mail address")]
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Required field")]
        public string Country { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Required field")]
        public string State { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Required field")]
        public string Phone { get; set; }

        [Display(Name = "Zip code")]
        [Required(ErrorMessage = "Required field")]
        public string Zip { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Reseller()
        {
            Orders = new HashSet<Order>();
        }
    }
}