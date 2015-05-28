using Kartastrof.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kartastrof.Classes;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

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

        public ActionResult GetClue()
        {

            //For use in response
            string capital = "Rio de Janeiro";
            //For use in get request
            string getCapital = capital.Replace(" ", "%20");

            string url = "http://en.wikipedia.org/w/api.php?action=query&prop=extracts&explaintext=true&exsectionformat=plain&titles=" + getCapital + "&format=json";

            //Get info from subscribers
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";


            try
            {
                //Read response
                var response = "empty";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                    streamReader.Close();
                }

                string[] lines = Regex.Split(response, "{");
                int i = 0;
                string serializeResponse = null;
                foreach (string line in lines)
                {
                    if (i == 4)
                    {
                        serializeResponse = "{" + line;
                    }
                    i++;
                }

                serializeResponse = serializeResponse.Remove(serializeResponse.Length - 3);
                //System.Diagnostics.Debug.WriteLine("SERIALIZERESPONE" + serializeResponse);

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                CapitalInfo capInfo = serializer.Deserialize<CapitalInfo>(serializeResponse);

                //Remove first part of extract (including translation to more languages and pronunciation), add new first part
                string[] splitted = capInfo.extract.Split(new string[] { " is " }, 2, StringSplitOptions.None);
                capInfo.extract = splitted[1];
                capInfo.extract = capInfo.extract.Replace(capital, "________");
                capInfo.extract = "______ is " + capInfo.extract;

                //Split into stanzas, save to clues
                string[] clues = Regex.Split(capInfo.extract, "\n\n\n");
                int j = 0; 
                foreach (string clueSplit in clues)
                {
                    //Delete double rowbreaks
                    clues[j] = clueSplit.Replace("\n\n", "\n");

                    capInfo.clues.Add(clues[j]);
                    j++;
                }

                System.Diagnostics.Debug.WriteLine("CLUE: " + capInfo.clues[0]);
                



            }
            catch
            {

                System.Diagnostics.Debug.WriteLine("GET REQUEST FOR CAPITAL FAILED");

            }






            return View();
        }
    }
}