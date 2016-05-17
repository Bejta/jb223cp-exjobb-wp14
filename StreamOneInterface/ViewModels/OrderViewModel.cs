using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namnet måste fyllas i")]
        //[MaxLength(100, ErrorMessage = "Namnet kan inte vara längre än {1} tecken.")]
        //[MinLength(2, ErrorMessage = "Namnet måste vara minst {1} tecken långt.")]
        public string OrderStreamOneID { get; set; }

        [Required(ErrorMessage = "Namnet måste fyllas i")]
        //[MaxLength(100, ErrorMessage = "Namnet kan inte vara längre än {1} tecken.")]
        //[MinLength(2, ErrorMessage = "Namnet måste vara minst {1} tecken långt.")]
        public string ListingID{ get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public List<OrderRowViewModel> OrderRows { get; set; }

        public OrderViewModel()
        {
            //Empty
        }
        public OrderViewModel(Order entity, bool useOrders = true)
        {
            Id = entity.Id;
            OrderStreamOneID = entity.OrderStreamOneID;
            ListingID = entity.ListingID;

            if (useOrders)
            {
                OrderRows = entity.OrderRows.Select(c => new OrderRowViewModel(c)).ToList();
            }
        }
    }
}