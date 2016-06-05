using Newtonsoft.Json.Linq;
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
            : this(new Service())
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
        [System.Web.Http.HttpPost]
        public void Post([FromBody]JToken json)
        {
            string rawJSON = json.ToString();

            /*
            * Token hardcoded just for test purpose.
            * The real token will be the part of HTTP POST Request, but
            * documentation from StreamOne API doesn't show in which way.
            * When StreamOne sends real data (even test order) it will be possible to catch the request
            * and give token variable real value from the request
            * 
            * */
            string token = "abc";
            _service.POSTCancellationOrder(token, rawJSON);
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
