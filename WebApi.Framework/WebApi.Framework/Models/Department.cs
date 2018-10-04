using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Framework.Models
{
    /// <summary>
    /// Department model
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Department Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Department Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string DepartnmentName { get; set; }
    }
}