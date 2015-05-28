using Kartastrof.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kartastrof.Classes;

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
            Session["latitude"] = correctAnswer.Ca_Latitude.ToString();
            Session["longitude"] = correctAnswer.Ca_Longitude.ToString();

            ViewBag.Message = "Your application description page.";

            return View(correctAnswer);
        }

        [HttpPost]
        public string Submit(string lat, string lng)
        {
            string answer = "Latitud: "+lat + " " +"Longitud: "+lng;
            
            if (isCorrectAnswer(lat, lng))
            {
                return "Grattis! Du gissade rätt! :D";
            } else{
                return "Tyvärr! Du gissade fel! Prova igen!!!";
            }
            //return answer;
        }

        public bool isCorrectAnswer(string lat, string lng) {
            bool isCorrect = false;
            double span = 0.5;

            double answerLat = double.Parse(lat, CultureInfo.InvariantCulture);
            double answerLng = double.Parse(lng, CultureInfo.InvariantCulture);
            double correctLat = double.Parse(Session["latitude"].ToString());
            double correctLng = double.Parse(Session["longitude"].ToString());
            /*
            if (Enumerable.Range(correctLat - span, correctLat + span).Contains(answerLat) && Enumerable.Range(correctLng - span, correctLng + span).Contains(answerLng))
            {
                isCorrect = true;
            }*/

            if (BetweenExtensions.IsBetweenII(answerLat, correctLat - span, correctLat + span) && BetweenExtensions.IsBetweenII(answerLng, correctLng - span, correctLng + span))
            {
                isCorrect = true;
            }


            return isCorrect;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}