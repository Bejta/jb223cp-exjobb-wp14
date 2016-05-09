using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Entities
{
    public class Reseller
    {

        public int Id { get; set; }

        public string CustomerID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Company { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Reseller()
        {
            Orders = new HashSet<Order>();
        }
    }
}