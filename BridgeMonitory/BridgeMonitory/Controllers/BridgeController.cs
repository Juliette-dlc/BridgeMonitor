using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BridgeMonitory.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BridgeMonitory.Controllers
{
    public class BridgeController
    {
        public class StationController : Controller
        {
            private const string _cookieKey = "stations";

            public IActionResult BoatName()
            {
                var stations = GetHoraireFromAPI();



                return View(stations);
            }

            public IActionResult ClosingType()
            {
                var stations = GetHoraireFromAPI();
                return View(stations);
            }

            private static List<HoraireList> GetHoraireFromAPI()
        {
            //Création un HttpClient (= outil qui va permettre d'interroger une URl via une requête HTTP)
            using (var client = new HttpClient())
            {
                //Interrogation de l'URL censée me retourner les données
                var response = client.GetAsync("https://api.alexandredubois.com/pont-chaban/api.php");
                //Récupération du corps de la réponse HTTP sous forme de chaîne de caractères
                var stringResult = response.Result.Content.ReadAsStringAsync();
                //Conversion de mon flux JSON (string) en une collection d'objets BikeStation
                //d'un flux de données vers des objets => Déserialisation
                //d'objets vers un flux de données => Sérialisation
                var result = JsonConvert.DeserializeObject<List<HoraireList>>(stringResult.Result);
                
                //var result = JsonConvert.DeserializeObject<List<HoraireList>>(stringResult.Result);
                return result;
            }
        }
    }
}
