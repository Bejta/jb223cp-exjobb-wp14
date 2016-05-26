using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Webservices.APIFacade
{
    public class APIFacadeReseller
    {
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
    }
}