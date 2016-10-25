using Fetch_N_Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fetch_N_Store.Controllers
{
    public class HomeController : Controller
    {

        private ResponseRepo repo = new ResponseRepo();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Responses()
        {
            ViewBag.Responses = repo.GetAllResponses().ToList();
            return View();
        }
    }
}