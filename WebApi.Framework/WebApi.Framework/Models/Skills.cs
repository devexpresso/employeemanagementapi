using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Framework.Models
{
    /// <summary>
    /// Skill Model
    /// </summary>
    public class Skills
    {
        /// <summary>
        /// Skill Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string SkillId { get; set; }

        /// <summary>
        /// Skill Name
        /// </summary>
        [JsonProperty(PropertyName = "skillname")]
        public string SkillName { get; set; }
    }
}