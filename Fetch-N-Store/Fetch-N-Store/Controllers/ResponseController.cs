using Fetch_N_Store.DAL;
using Fetch_N_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fetch_N_Store.Controllers
{
    public class ResponseController : ApiController
    {
        private ResponseRepo repo = new ResponseRepo();

        List<Response> Responses = new List<Response>();


        public IEnumerable<Response> Get()
        {
            Responses = repo.GetAllResponses();
            return Responses;
        }

        public HttpResponseMessage Post(Response response)
        {
            repo.AddResponse(response);
            var headresponse = Request.CreateResponse<Response>(System.Net.HttpStatusCode.Created, response);
 
            return headresponse;
        }
    }
}
