using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AnimeDB.Models.Requests;
using AnimeDB.Models.Responses;
using AnimeDB.Services.Interfaces;
using Microsoft.Practices.Unity;

namespace AnimeDB.Controllers.Api
{
    public class RoleController: ApiController
    {
        [Dependency]
        public IRoleService _IRoleService { get; set; }

        [Route(), HttpGet]
        public HttpResponseMessage InsertRole(InsertRoleRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();
            
            if (model != null)
            {
                response.Item = _IRoleService.InsertRole(model);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}