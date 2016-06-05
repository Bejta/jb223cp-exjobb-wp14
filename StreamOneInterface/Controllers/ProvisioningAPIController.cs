using Newtonsoft.Json.Linq;
using StreamOneInterface.Models;
using StreamOneInterface.Models.Abstract;
using StreamOneInterface.Models.Webservices;
using StreamOneInterface.Models.Webservices.APIFacade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace StreamOneInterface.Controllers
{
    public class ProvisioningAPIController : ApiController
    {

        private IService _service;

        public ProvisioningAPIController()
            : this(new Service())
        { }
        public ProvisioningAPIController(IService service)
        {
            _service = service;
        }

        // GET: api/ProvisioningAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProvisioningAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProvisioningAPI
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post([FromBody]JToken json)
        {
          
            string rawJSON=json.ToString();

            APIFacadeOrder _APIOrder = new APIFacadeOrder();
           
            /*
             * Token hardcoded just for test purpose.
             * The real token will be the part of HTTP POST Request, but
             * documentation from StreamOne API doesn't show in which way.
             * When StreamOne sends real data (even test order) it will be possible to catch the request
             * and give token variable real value from the request
             * 
             * */
            string token = "abs";
           _APIOrder = _service.POSTProvisionalOrder(token, rawJSON);
           return  Request.CreateResponse(HttpStatusCode.OK, _APIOrder.return_message);
  
        }

        // PUT: api/ProvisioningAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProvisioningAPI/5
        public void Delete(int id)
        {
        }
    }
}
