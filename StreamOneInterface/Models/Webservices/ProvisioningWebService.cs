using StreamOneInterface.Models.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace StreamOneInterface.Models.Webservices
{
    public class ProvisioningWebService : WebServiceBase
    {

        /** public provisioning method -­‐ accepts:
         *  provision_data(the json encoded data from post array),
         *  token(the 32 character UUID auth token from the post array)
        **/
        public string ProvisionApp(String provision_data, String token)
        {
            /** define and initialize variables
             * To exit test mode and use live data change the mode variable to "live"
             **/

            string mode = "test";
            string postedData;
            string returnData = "";

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Hashtable dataTable = new Hashtable();

            // set test or live mode

            if (mode == "test")
            {

            }
            else
            {
                /* when not in test mode this initializes the posted_data variable
                 *  to the live marketplace provision_data
                 */
                postedData = provision_data;
            }
        }

    }
}