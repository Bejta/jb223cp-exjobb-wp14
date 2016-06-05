using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace StreamOneInterface.Models.Abstract
{
    public class WebServiceBase
    {

        public string ReadJSONData(string fileName)
        {
            var rawJSON = string.Empty;

            //Reads data from messages.json file
            using (var readerCashe = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/" + fileName)))
            {
                rawJSON = readerCashe.ReadToEnd();
            }

             /* It is possible to add functionality of converting to JSON object of Order type
              * 
              * var json_serializer = new JavaScriptSerializer();
              * var result = JsonConvert.DeserializeObject<Order>(rawJSON).messages;
              * 
             */
            return rawJSON;
        }

        /// <summary>
        /// Function for authentiaction of Request by given token
        /// </summary>
        /// <param name="token"></param>
        /// <returns>true/false</returns>
        public bool VerifyAuthString(string token)
        {
            string tokenCheckUrl = "https://www.tdstreamone.eu/tokenizer/auth.php?token=" + token + "&task=authorize";
            HttpWebRequest StreamOneRequest = (HttpWebRequest)WebRequest.Create(tokenCheckUrl);
            StreamOneRequest.Method = "GET";
            WebResponse StreamOneResponse = StreamOneRequest.GetResponse();

            StreamReader streamReader = new StreamReader(StreamOneResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = streamReader.ReadToEnd();

            streamReader.Close();
            StreamOneResponse.Close();

            /*
             * IMPORTANT: As in test mode, this function should always return TRUE so
             * that we can assume that authorization is done on streamOne Url.
             * However, when in real mode (or test mode with StreamOne LIVE test API) the code bellow
             * should be uncommented so that true is returned only when response message is "Ok".
             * Of course the last return on line 70 should be commented.
             * 
             * */

            //if (result != "Ok")
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}

            return true;
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true /* disposing */);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}