using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.ViewModels
{
    public class OrderRowsViewModel
    {
        public List<OrderViewModel> Orders { get; set; }

        public OrderRowsViewModel()
        {
            //Empty
        }
        public OrderRowsViewModel(List<Order> orders)
        {
            Orders = orders.Select(g => new OrderViewModel(g)).ToList();
        }
    }
}