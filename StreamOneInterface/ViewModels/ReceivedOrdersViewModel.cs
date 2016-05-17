using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.ViewModels
{
    public class ReceivedOrdersViewModel
    {
            public IEnumerable<Order> Orders { get; set; }
            public IEnumerable<OrderRow> OrderRows { get; set; }
            //public IEnumerable<Product> Products { get; set; }
    }
}