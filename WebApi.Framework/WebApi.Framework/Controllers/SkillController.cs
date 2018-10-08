using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Framework.Models;

namespace WebApi.Framework.Controllers
{
    /// <summary>
    /// Skills
    /// </summary>
    public class SkillController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        public SkillController()
        {
            DocumentDBRepository<Skills>.Initialize("Skills");
        }
        /// <summary>
        /// Get All Skills
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllSkills")]
        public async Task<HttpResponseMessage> GetAllSkills()
        {
            try
            {
                var result = await DocumentDBRepository<Skills>.GetItemsAsync();
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Get Skill by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetSkill/{id}")]
        public async Task<HttpResponseMessage> GetSkill(string id)
        {
            try
            {
                var result = await DocumentDBRepository<Skills>.GetItemsAsync(d => d.SkillId == id);
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Add Skill
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddSkill")]
        public async Task<HttpResponseMessage> AddSkill([System.Web.Mvc.Bind(Include = "SkillId,SkillName")] Skills skill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Skills>.CreateItemAsync(skill);

                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Update a Skill
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateSkill")]
        public async Task<HttpResponseMessage> UpdateSkill([System.Web.Mvc.Bind(Include = "SkillId,SkillName")] Skills skill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Skills>.UpdateItemAsync(skill.SkillId, skill);

                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        /// <summary>
        /// Delete Skill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteSkill/{id}")]
        public async Task<HttpResponseMessage> DeleteSkill(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

                await DocumentDBRepository<Skills>.DeleteItemAsync(id);

                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
    }
}
