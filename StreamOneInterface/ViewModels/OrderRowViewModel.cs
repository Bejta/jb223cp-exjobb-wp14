using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.ViewModels
{
    public class OrderRowViewModel
    {
        [Key]
        [Display(Name = "Item Status ID")]
        [Required(ErrorMessage = "Required field")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int OrderRowStatusId { get; set; }

        [Required(ErrorMessage = "Required field")]
        public OrderRowStatus OrderRowStatus { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Required field")]
        public float UnitPrice { get; set; }

        [Required(ErrorMessage = "Required field")]
        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public OrderRowViewModel()
        {
            //Empty
        }

        public OrderRowViewModel(OrderRow entity)
        {
            Id = entity.Id;
            Quantity = entity.Quantity;
            UnitPrice = entity.UnitPrice;
            Id = entity.Id;
            Id = entity.Id;
            //OrderRowStatus.RowStatus = entity.Name;
            //Description = entity.Description;
            //Queries = entity.Queries.Select(q => new PropertyQueryInfoViewModel(q)).ToList();
            //OrganisationalUnits = entity.OrganisationalUnits.Select(o => new OrganisationalUnitInfoViewModel(o)).ToList();
            //GroupCategory = new GroupCategoryViewModel(entity.GroupCategory, false);
            //OrderRowStatus = new OrderRowStatusViewModel(entity.OrderRowStatus);
        }
    }
}