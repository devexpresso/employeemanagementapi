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
    /// Client
    /// </summary>
    public class ClientController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        public ClientController()
        {
            DocumentDBRepository<Client>.Initialize("Client");
        }
        /// <summary>
        /// Get All Clients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllClients")]
        public async Task<HttpResponseMessage> GetAllClients()
        {
            try
            {
                var result = await DocumentDBRepository<Client>.GetItemsAsync();
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
        /// Get Client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetClient/{id}")]
        public async Task<HttpResponseMessage> GetClient(string id)
        {
            try
            {
                var result = await DocumentDBRepository<Client>.GetItemsAsync(d => d.ClientId == id);
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
        /// Add Client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddClient")]
        public async Task<HttpResponseMessage> AddClient([System.Web.Mvc.Bind(Include = "ClientId,ClientName,ClientLocation")] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Client>.CreateItemAsync(client);

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
        /// Update a Client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateClient")]
        public async Task<HttpResponseMessage> UpdateClient([System.Web.Mvc.Bind(Include = "ClientId,ClientName,ClientLocation")] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Client>.UpdateItemAsync(client.ClientId, client);

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
        /// Delete Client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteClient/{id}")]
        public async Task<HttpResponseMessage> DeleteClient(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

                await DocumentDBRepository<Client>.DeleteItemAsync(id);

                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
    }
}
