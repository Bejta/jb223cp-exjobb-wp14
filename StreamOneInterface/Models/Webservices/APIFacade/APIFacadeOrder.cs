using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Webservices.APIFacade
{
    public class APIFacadeOrder
    {
        //order
        public string order_id { get; set; }
        public string listing_id { get; set; }
        public string return_message { get; set; }
        //public string customer_id { get; set; }

        //resellers
        public string customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string company_website { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string phone { get; set; }
        public string zip { get; set; }

        public APIFacadeReseller reseller { get; set; }
        //public IEnumerable<APIFacadeOrderRow> orderrows { get; set; }
        public List<APIFacadeOrderRow> Items { get; set; }
        //public APIFacadeItems items { get; set; }
    }
}