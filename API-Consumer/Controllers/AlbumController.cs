using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_Consumer.Models;

using Coursework2.Shared;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace API_Consumer.Controllers
{
    public class AlbumController : Controller
    {
        private readonly ILogger<AlbumController> _logger;

        public AlbumController(ILogger<AlbumController> logger)
        {
            _logger = logger;
        }

        [Route("Albums")]
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");

            // Will wait at the below line of code until we get a response from the API, and then we can move on to this line of code 
            HttpResponseMessage response = await client.GetAsync("Albums/");
            string jsonString = await response.Content.ReadAsStringAsync();
            // Takes the JSON that's returned from the web service (jsonString), assumes string type, deserializes it in to a collection
            IEnumerable<Album> model = JsonConvert.DeserializeObject<IEnumerable<Album>>(jsonString);
            return View(model);
        }


        [Route("Albums/{id}")]
        public async Task<IActionResult> AlbumById()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");

            // Will wait at the below line of code until we get a response from the API, and then we can move on to this line of code 
            int id = 4;
            HttpResponseMessage response = await client.GetAsync($"Albums/{id}");
            string jsonString = await response.Content.ReadAsStringAsync();
            // Takes the JSON that's returned from the web service (jsonString), assumes string type, deserializes it in to a collection
            IEnumerable<Album> model = JsonConvert.DeserializeObject<IEnumerable<Album>>(jsonString);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
