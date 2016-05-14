using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.ViewModels
{
    public class ResellerViewModel
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "Required field")]
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

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Required field")]
        public string Country { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Required field")]
        public string Phone { get; set; }

        [Display(Name = "Zip code")]
        [Required(ErrorMessage = "Required field")]
        public string Zip { get; set; }

        public ResellerViewModel()
        {
            //Empty
        }
        public ResellerViewModel(Reseller entity)
        {
            Id = entity.Id;
            CustomerID = entity.CustomerID;
            Firstname = entity.Firstname;
            Lastname = entity.Lastname;
            Address1 = entity.Address1;
            Address2 = entity.Address2;
            City = entity.City;
            Company = entity.Company;
            Website = entity.Website;
            Email = entity.Email;
            Country = entity.Country;
            State = entity.State;
            Phone = entity.Phone;
            Zip = entity.Zip;
        }
    }
}