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
    }
}