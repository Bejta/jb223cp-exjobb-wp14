using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StreamOneInterface.Models.Abstract;
using StreamOneInterface.Models.Entities;
using StreamOneInterface.Models.Webservices.APIFacade;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace StreamOneInterface.Models.Webservices
{
    public class ProvisioningWebService : WebServiceBase, IProvisioningWebService
    {

        private IService _service;

        private readonly ISettings _settings;
        public ProvisioningWebService() : this(new Settings(true), new Service())
        {
            //Empty...
        }

        public ProvisioningWebService(Settings settings, Service service)
        {
            _settings = settings;
            _settings.Save();
            _service = service;
        }

        /** public provisioning method -­‐ accepts:
         *  provision_data(the json encoded data from post array),
         *  token(the 32 character UUID auth token from the post array)
        **/
        public APIFacadeOrder ProvisionApp(string token, string provisionData)
        {

            /** define and initialize variables
             * To exit test mode and use live data change the mode variable to "live"
             **/

            string mode = _settings.Mode;
            //string token = _settings.Token;
            string postedData;
            string returnData = "";

            if (mode == "Test")
            {
                postedData = ReadJSONData("testorder.json");
            }
            else
            {
                /* when not in test mode this initializes the posted_data variable
                 *  to the live marketplace provision_data
                 */
                postedData = provisionData;
            }


            APIFacadeOrder order = new APIFacadeOrder();

            /* Authenticate this
             * provision using token
             * */
            if (!VerifyAuthString(token))
            {
                /* Generate an internal alert or message log for a failed authentication*/
                string validationError = "Failed Authentication";
                order.return_message = validationError;
                return order;
            }

            order = JsonConvert.DeserializeObject<APIFacadeOrder>(postedData);
            
            //JObject jsonObject = JObject.Parse(postedData);
            //var items = jsonObject.Property("items");

            /* 
             * This loop checks if all products on 
             * TODO: Separate this code to a function
             * */
            foreach (var i in order.Items)
            {
                if (_service.GetActiveProductByS1ID(i.product_id) == null)
                {
                    string validationError = "Unknown or Inactive product found in order items";
                    order.return_message = validationError;
                    return order;
                }
            }

            /*
             * Checks if reseller is unknown or available.
             * If unknows, saves reseller in database
             * TODO: Separate this code to a function
             * */

            if (_service.GetResellerByS1ID(order.customer_id)==null)
            {
                Reseller dbReseller = new Reseller();

                dbReseller.Address1 = order.address1;
                dbReseller.Address2 = order.address2;
                dbReseller.City = order.city;
                dbReseller.Company = order.company;
                dbReseller.Website = order.company_website;
                dbReseller.Phone = order.phone;
                dbReseller.State = order.state;
                dbReseller.Zip = order.zip;
                dbReseller.Email = order.email;
                dbReseller.Firstname = order.first_name;
                dbReseller.Lastname = order.last_name;
                dbReseller.CustomerID = order.customer_id;
                dbReseller.Country = order.country;

                if (!_service.InsertReseller(dbReseller))
                {
                    string validationError = "Not possible to save reseller to the database";
                    order.return_message = validationError;
                    return order;
                }
            }

            //Represents Order table in the database
            Order dbOrder = new Order();

            Reseller reseller = _service.GetResellerByS1ID(order.customer_id);
            int resellerID = reseller.Id;

            dbOrder.ResellerID = resellerID;
            dbOrder.Date = DateTime.Now;
            dbOrder.LastUpdated = DateTime.Now;
            dbOrder.ListingID = order.listing_id;
            dbOrder.OrderStreamOneID = order.order_id;
            dbOrder.OrderStatusID = 1; //Status is always by default with id 1
            dbOrder.OrderTypeID = 1; // Type is always by default with id 1

            if (!_service.InsertOrder(dbOrder))
            {
                string validationError = "Reseller was saved in a database, but order could not be saved!";
                order.return_message = validationError;
                return order;
            }

            OrderRow dbOrderRow = new OrderRow();
            Product product = new Product();

            /*
             * IMPORTANT: product_id is StreamOne string value and IS UNIQUE in Product table.. 
             * in the database. However, the real primary key for a table is Id field.
             */
            foreach(var i in order.Items)
            {
                product = _service.GetActiveProductByS1ID(i.product_id);

                dbOrderRow.OrderID = dbOrder.Id; // ?? Should be correct, but can calculate if needed
                dbOrderRow.OrderRowStatusID = 1; // The first status is always default value
                dbOrderRow.Quantity = i.quantity;
                dbOrderRow.Description = i.item_description;
                dbOrderRow.UnitPrice = i.unit_price;
                dbOrderRow.ItemID = i.item_id;
                dbOrderRow.ProductID = product.Id;
                dbOrderRow.StreamOneID = i.product_id;

                if (!_service.InsertOrderRow(dbOrderRow))
                {
                    string validationError = "Reseller and Order were saved in the database, but items could not be saved.";
                    order.return_message = validationError;
                    return order;
                }
            }

            /* Webservice page should return the data which will be used by the Marketplace to populate
             * the getting started webpage
             */
            returnData += "<status>success</status>" + "<username>username</username>" + "<password>password</password>" + "<url>http://www.partnersite.com/login</url>";
            order.return_message = returnData;
            return order;
        }
    }
}

