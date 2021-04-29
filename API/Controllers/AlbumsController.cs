using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Coursework2.Shared;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AlbumsController> _logger;

        public AlbumsController(ILogger<AlbumsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            ChinookDb db = new ChinookDb();
            IList<Album> Albums = db.Albums.ToList();
            string JSON = JsonConvert.SerializeObject(Albums);
            return JSON;
        }
    }
}
