using StreamOneInterface.Models;
using StreamOneInterface.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StreamOneInterface.Controllers
{
    public class CancellationAPIController : ApiController
    {

        private IService _service;

        public CancellationAPIController()
            : this (new Service())
        { }
        public CancellationAPIController(IService service)
        {
            _service = service;
        }
        // GET: api/CancellationAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CancellationAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CancellationAPI
        public void Post(string token,[FromBody]string json)
        {
            
            _service.POSTCancellationOrder(token, json);
        }

        // PUT: api/CancellationAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CancellationAPI/5
        public void Delete(int id)
        {
        }
    }
}
