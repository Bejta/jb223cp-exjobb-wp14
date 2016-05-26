using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Webservices.APIFacade
{
    public class APIFacadeOrderRow
    {
        public string item_id { get; set; }
        public string product_id { get; set; }
        public int quantity { get; set; }
        public string item_description { get; set; }
        public float unit_price { get; set; }
    }
}