using Kartastrof.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kartastrof.Controllers
{
    public class HomeController : Controller
    {
        private Capital db = new Capital();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Play()
        {

            //Slumpa fram en stad
            int count = db.Tbl_Capital.Count();
            Random rnd = new Random();
            int randomNr = rnd.Next(0, count);
            Tbl_Capital correctAnswer = db.Tbl_Capital.Find(randomNr);

            ViewBag.Message = "Your application description page.";

            return View(correctAnswer);
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