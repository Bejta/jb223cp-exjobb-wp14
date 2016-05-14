using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.ViewModels
{
    public class OrderStatusViewModel
    {
        [Display(Name = "Status ID")]
        [Required(ErrorMessage = "Required field")]
        public int Id { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Required field")]
        public string Status { get; set; }

        public OrderStatusViewModel()
        {
            //Empty
        }
        public OrderStatusViewModel(OrderStatus entity)
        {
            Id = entity.Id;
            Status = entity.Status;
        }
    }
}