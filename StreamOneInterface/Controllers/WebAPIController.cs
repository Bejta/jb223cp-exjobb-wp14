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
    
    public class WebAPIController : ApiController
    {

        private IService _service;

        public WebAPIController()
            : this (new Service())
        { }
        public WebAPIController(IService service)
        {
            _service = service;
        }


        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}