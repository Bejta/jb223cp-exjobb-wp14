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
        public string return_message { get; set; }
        public string customer_id { get; set; }
        
        public APIFacadeReseller reseller { get; set; }
        public IEnumerable<APIFacadeOrderRow> orderrows { get; set; }
        public APIFacadeItems items { get; set; }
    }
}