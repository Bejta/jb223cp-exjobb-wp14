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
        public int Id { get; set; }

        [Required(ErrorMessage = "Field required")]
        //[MaxLength(100, ErrorMessage = "Namnet kan inte vara längre än {1} tecken.")]
        //[MinLength(2, ErrorMessage = "Namnet måste vara minst {1} tecken långt.")]
        public string Type { get; set; }

        public List<OrderViewModel> Orders { get; set; }

        public OrderTypeViewModel()
        {
            //Empty
        }
        public OrderTypeViewModel(OrderType entity, bool useOrders = true)
        {
            Id = entity.Id;
            Type = entity.Type;

            if (useOrders)
            {
                Orders = entity.Orders.Select(c => new OrderViewModel(c)).ToList();
            }
        }
    }
}