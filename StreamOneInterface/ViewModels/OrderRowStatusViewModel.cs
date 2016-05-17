﻿using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.ViewModels
{
    public class OrderRowStatusViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Namnet måste fyllas i")]
        //[MaxLength(100, ErrorMessage = "Namnet kan inte vara längre än {1} tecken.")]
        //[MinLength(2, ErrorMessage = "Namnet måste vara minst {1} tecken långt.")]
        public string Status { get; set; }

        public List<OrderRowViewModel> OrderRows { get; set; }

        public OrderRowStatusViewModel()
        {
            //Empty
        }
        public OrderRowStatusViewModel(OrderRowStatus entity, bool useOrderRows = true)
        {
            Id = entity.Id;
            Status = entity.RowStatus;

            if (useOrderRows)
            {
                OrderRows = entity.OrderRows.Select(c => new OrderRowViewModel(c)).ToList();
            }
        }
    }
}