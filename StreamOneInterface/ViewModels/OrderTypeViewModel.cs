using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.ViewModels
{
    public class OrderTypeViewModel
    {
        [Display(Name = "Type ID")]
        [Required(ErrorMessage = "Required field")]
        public int Id { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Required field")]
        public string Type { get; set; }

        public OrderTypeViewModel()
        {
            //Empty
        }
        public OrderTypeViewModel(OrderType entity)
        {
            Id = entity.Id;
            Type = entity.Type;
        }
    }
}