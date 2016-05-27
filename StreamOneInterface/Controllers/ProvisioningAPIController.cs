using StreamOneInterface.Models;
using StreamOneInterface.Models.Abstract;
using StreamOneInterface.Models.Webservices;
using StreamOneInterface.Models.Webservices.APIFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StreamOneInterface.Controllers
{
    public class ProvisioningAPIController : ApiController
    {

        private IService _service;

        public ProvisioningAPIController()
            : this (new Service())
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
        public HttpResponseMessage Post(string token, [FromBody]string json)
        {
            if (token == null || json==null)
               return new HttpResponseMessage(HttpStatusCode.BadRequest);

           APIFacadeOrder _APIOrder = new APIFacadeOrder();
           _APIOrder = _service.POSTProvisionalOrder(token, json);
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
