using Newtonsoft.Json;
using Practica7.MVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Practica7.MVC.Controllers
{
    public class SwapiController : Controller
    {
        private readonly string swapiPeopleUrl = "https://swapi.dev/api/people/";

        public async Task<ActionResult> Index()
        {
            var charachterId = new int[] {1, 5, 10, 11 };
            var characters = new List<CharacterView>();

            using (var httpClient = new HttpClient())
            {
                foreach (var id in charachterId)
                {
                    var response = await httpClient.GetAsync($"https://swapi.dev/api/people/{id}/");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var character = JsonConvert.DeserializeObject<CharacterView>(json);
                        characters.Add(character);

                    }
                }

                return View(characters);
            }
        }
    }
}