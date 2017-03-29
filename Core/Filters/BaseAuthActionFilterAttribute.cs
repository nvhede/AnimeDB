using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Core.Filters
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class BaseAuthActionFilterAttribute : ActionFilterAttribute
    {
        public string EntityIdField { get; set; }

        public int EntityTypeId { get; set; }

        public EntityActionType Action { get; set; }

        /*
         *  these three functions are all different versions of _HandleInvalidRequest() but they do slightly different things
         *  based on what you pass into the function. this is an example of Polymorphism.
         */
        protected void _HandleRequestError(HttpStatusCode statusCode)
        {
            _HandleRequestError("Internal Server Error", statusCode);
        }

        protected void _HandleRequestError(string reason)
        {
            _HandleRequestError(reason, HttpStatusCode.InternalServerError);
        }

        protected void _HandleRequestError(string reason, HttpStatusCode statusCode)
        {
            HttpResponseMessage response = new HttpResponseMessage(statusCode);

            response.ReasonPhrase = reason;

            throw new HttpResponseException(response);
        }

        protected void _HandleValidationErrorRequest(string reason)
        {
            _HandleRequestError(reason, HttpStatusCode.BadRequest);
        }

        protected void _HandleValidationErrorRequest()
        {
            _HandleRequestError("Request data is invalid", HttpStatusCode.BadRequest);
        }

        protected void _HandleUnauthorizedRequest(string reason)
        {
            _HandleRequestError(reason, HttpStatusCode.Unauthorized);
        }

        protected void _HandleUnauthorizedRequest()
        {
            _HandleRequestError("Unauthorized", HttpStatusCode.Unauthorized);
        }
    }
}
