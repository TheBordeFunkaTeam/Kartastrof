using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kartastrof.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Play()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public string Submit(string lat, string lng)
        {
            string answer = "Latitud: "+lat + " " +"Longitud: "+lng;
            return answer;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}