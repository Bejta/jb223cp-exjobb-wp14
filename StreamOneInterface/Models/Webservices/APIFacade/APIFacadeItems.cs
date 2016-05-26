using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models.Webservices.APIFacade
{
    /// <summary>
    /// Represents
    /// </summary>
    public class APIFacadeItems
    {
        [JsonProperty("items")]
        public List<APIFacadeOrderRow> Items { get; set; }
    }
}