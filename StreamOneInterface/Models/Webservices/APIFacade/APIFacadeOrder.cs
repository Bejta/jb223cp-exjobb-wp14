using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Webservices.APIFacade
{
    public class APIFacadeOrder
    {
        public string order_id { get; set; }
        public string listing_id { get; set; }
        public string customer_id { get; set; }
    }
}