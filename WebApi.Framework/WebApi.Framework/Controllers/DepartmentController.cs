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
    /// Accounts
    /// </summary>
    public class DepartmentController : ApiController
    {
        private const string CollectionId = "Department";

        public DepartmentController()
        {
            DocumentDBRepository<Department>.Initialize("Department");
        }
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllDepartments")]
        public async Task<HttpResponseMessage> GetAllDepartments()
        {
            try
            {
                var accounts = await DocumentDBRepository<Department>.GetItemsAsync();
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(accounts), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Get Department by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetDepartment/{id}")]
        public async Task<HttpResponseMessage> GetDepartment(string id)
        {
            try
            {
                var account = await DocumentDBRepository<Department>.GetItemsAsync(d => d.DepartmentId == id);
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Add Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddDepartment")]
        public async Task<HttpResponseMessage> AddDepartment([System.Web.Mvc.Bind(Include = "DepartmentId,DepartmentName")] Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Department>.CreateItemAsync(department);

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
        /// Update a Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateDepartment")]
        public async Task<HttpResponseMessage> UpdateDepartment([System.Web.Mvc.Bind(Include = "DepartmentId,DepartmentName")] Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Department>.UpdateItemAsync(department.DepartmentId, department);

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
        /// Delete Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteDepartment/{id}")]
        public async Task<HttpResponseMessage> DeleteDepartment(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

                await DocumentDBRepository<Department>.DeleteItemAsync(id);

                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
    }
}
