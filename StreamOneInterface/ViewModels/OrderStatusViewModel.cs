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
        public int Id { get; set; }

        [Required(ErrorMessage = "Namnet måste fyllas i")]
        //[MaxLength(100, ErrorMessage = "Namnet kan inte vara längre än {1} tecken.")]
        //[MinLength(2, ErrorMessage = "Namnet måste vara minst {1} tecken långt.")]
        public string Status { get; set; }

        public List<OrderViewModel> Orders { get; set; }

        public OrderStatusViewModel()
        {
            //Empty
        }
        public OrderStatusViewModel(OrderStatus entity, bool useOrders = true)
        {
            Id = entity.Id;
            Status = entity.Status;

            if (useOrders)
            {
                Orders = entity.Orders.Select(c => new OrderViewModel(c)).ToList();
            }
        }
    }
}