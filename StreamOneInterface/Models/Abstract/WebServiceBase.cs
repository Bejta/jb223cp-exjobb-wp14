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

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
        }

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

            if (result != "Ok")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Dispose()
        {
            Dispose(true /* disposing */);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}