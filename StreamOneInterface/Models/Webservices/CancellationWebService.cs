using StreamOneInterface.Models.Abstract;
using StreamOneInterface.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace StreamOneInterface.Models.Webservices
{
    public class CancellationWebService : WebServiceBase, ICancellationWebService
    {

        private IService _service;

        private readonly ISettings _settings;
        public CancellationWebService() : this(new Settings(true), new Service())
        {
            //Empty...
        }

        public CancellationWebService(Settings settings, Service service)
        {
            _settings = settings;
            _settings.Save();
            _service = service;
        }
        public void CancelSubscription(string provision_data, string token)
        {
            /* Declare method variables
            **/
            string postedData;
            string customerId;
            string itemId;
            string action;
            string returnJSON = "";


            /* deserialize JSON data
            **/
            postedData = provision_data;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Hashtable dataTable = new Hashtable();
            dataTable = serializer.Deserialize<Hashtable>(postedData);


            /* Initialize declared variables with data from hash table above
            **/
            customerId = (string)dataTable["customer_id"];
            itemId = (string)dataTable["item_id"];
            action = (string)dataTable["action"];


            /* Authenticate this provision using token
            **/
            if (!VerifyAuthString(token))
            {
                returnJSON = ReadJSONData("failedauthentication.json");
                /*  Print out the failed json for marketplace listener
                **/
                Console.WriteLine(returnJSON);
                return;
            }
            else
            {

                OrderRow dbOrderRow = new OrderRow();
                dbOrderRow = _service.GetOrderRowByItemId(itemId);

                if (dbOrderRow == null)
                {
                    returnJSON = ReadJSONData("noitem.json");
                    Console.WriteLine(returnJSON);
                    return;
                }
                dbOrderRow.OrderRowStatusID = 2;

                if(_service.UpdateOrderRow(dbOrderRow))
                {
                    returnJSON = ReadJSONData("success.json");
                    Console.WriteLine(returnJSON);
                    return;
                }
                returnJSON = ReadJSONData("notupdated.json");
                Console.WriteLine(returnJSON);
                return;
            }
        }
    }
}