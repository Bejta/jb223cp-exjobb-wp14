using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.ViewModels
{
    public class OrderRowStatusViewModel
    {
        [Display(Name = "Item Status ID")]
        [Required(ErrorMessage = "Required field")]
        public int Id { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Required field")]
        public string Status { get; set; }

        public OrderRowStatusViewModel()
        {
            //Empty
        }
        public OrderRowStatusViewModel(OrderRowStatus entity)
        {
            Id = entity.Id;
            Status = entity.RowStatus;
        }
    }
}