using StreamOneInterface.Models.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace StreamOneInterface.Models.Webservices
{
    public class CancellationWebService : WebServiceBase
    {
        public void CancelSubscription(string provision_data, string token)
        {
            /* Declare method variables
            **/
            string postedData;
            string customerId;
            string itemId;
            string action;
            string returnJSON ="";


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
                /* Handle local cancellation code here.
                 * 1. Update local database
                 * 2. Create error message
                 * 3. Or, send email notifications.
                **/

                /*
                  TODO
                */

                /* Create associative array of status and pw to return
                 *  to the marketplace listener
                **/
                returnJSON= ReadJSONData("failedauthentication.json");
                /*  Print out the failed json for marketplace listener
                **/
                Console.WriteLine(returnJSON);
                return;
            }
            else
            {
                returnJSON = ReadJSONData("success.json");
                Console.WriteLine(returnJSON);
                return;
            }
        }