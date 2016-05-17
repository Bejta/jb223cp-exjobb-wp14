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

        public List<OrderViewModel> Orders { get; set; }

        public ResellerViewModel()
        {
            //Empty
        }
        public ResellerViewModel(Reseller entity, bool useOrders = true)
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

            if (useOrders)
            {
                Orders = entity.Orders.Select(c => new OrderViewModel(c)).ToList();
            }
        }
        public Reseller ToEntity(Reseller existing = null)
        {
            Reseller entity = (existing != null ? existing : new Reseller());

            entity.Id = this.Id;
            entity.CustomerID = this.CustomerID;
            entity.Firstname = this.Firstname;
            entity.Lastname = this.Lastname;
            entity.Address1 = this.Address1;
            entity.Address2 = this.Address2;
            entity.City = this.City;
            entity.Company = this.Company;
            entity.Website = this.Website;
            entity.Email = this.Email;
            entity.Country = this.Country;
            entity.State = this.State;
            entity.Phone = this.Phone;
            entity.Zip = this.Zip;
            
            return entity;
        }
    }
}