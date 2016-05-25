using StreamOneInterface.Models.Abstract;
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

        private readonly ISettings _settings;
        public ProvisioningWebService() : this(new Settings(true))
        {
            //Empty...
        }

        public ProvisioningWebService(Settings settings)
        {
            _settings = settings;
            _settings.Save();
        }

        /** public provisioning method -­‐ accepts:
         *  provision_data(the json encoded data from post array),
         *  token(the 32 character UUID auth token from the post array)
        **/
        public string ProvisionApp(String provisionData, String token)
        {

            /** define and initialize variables
             * To exit test mode and use live data change the mode variable to "live"
             **/

            string mode = _settings.Mode;
            //string token = _settings.Token;
            string postedData;
            string returnData = "";

            if (mode == "test")
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

            /* Authenticate this
             * provision using token
             * */
            if (!VerifyAuthString(token))
            {
                /* Generate an internal alert or message log for a failed authentication*/
                string validationError = "Failed Authentication";
                return validationError;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Hashtable dataTable = new Hashtable();

            //The hashtable dataTable now contains all of the variables passed to the partner webservice.
            if (mode == "test")
            {
                foreach (DictionaryEntry data in dataTable)
                {
                    returnData += "Key:" + data.Key + "Value:" + data.Value + "";
                }
            }

            /* Webservice page should return the data which will be used by the Marketplace to populate
             * the getting started webpage
             */
            returnData += "<status>success</status>" + "<username>username</username>" + "<password>password</password>" + "<url>http://www.partnersite.com/login</url>";
            return returnData;

        }
    }
}

