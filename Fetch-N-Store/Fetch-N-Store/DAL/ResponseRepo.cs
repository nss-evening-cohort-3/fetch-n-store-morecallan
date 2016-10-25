using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fetch_N_Store.Models;


namespace Fetch_N_Store.DAL
{
    public class ResponseRepo
    {
        public ResponseContext Context { get; set; }

        public ResponseRepo()
        {
            Context = new ResponseContext();
        }

        public ResponseRepo(ResponseContext _context)
        {
            Context = _context;
        }

        public List<Response> GetAllResponses()
        {
            return Context.Responses.ToList();
        }

        public Response GetSingleResponseById(int id)
        {
            Response found_response = Context.Responses.FirstOrDefault(a => a.ResponseId == id);
            return found_response;
        }

        public void AddResponse(Response _response)
        {
            Context.Responses.Add(_response);
            Context.SaveChanges();
        }
    }
}