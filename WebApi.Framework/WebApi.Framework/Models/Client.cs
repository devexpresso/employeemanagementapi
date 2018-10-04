using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Framework.Models
{
    /// <summary>
    /// Client model
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string ClientId { get; set; }
        /// <summary>
        /// Client name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string ClientName { get; set; }
        /// <summary>
        /// Client location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string ClientLocation { get; set; }
    }
}