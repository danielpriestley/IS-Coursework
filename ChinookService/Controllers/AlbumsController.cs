using Microsoft.AspNetCore.Mvc;
using Coursework2.Shared;
using ChinookService.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace ChinookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {

        private IAlbumsRepository repo;

        // contructor injects repo registered in startup
        public AlbumsController(IAlbumsRepository repo)
        {
            this.repo = repo;
        }

        // GET:  /api/albums
        // GET: /api/albums/?artist=[artistId]
        // this will always return a list of albums even if the url is empty
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Album>))]
        public async Task<IEnumerable<Album>> GetAlbums(int ArtistId)
        {
            // string strArtistId = ArtistId.ToString();
            // Album a = await repo.RetrieveAsync(ArtistId);
            int? id = ArtistId;

            if (id == null)
            {
                return await repo.RetrieveAllAsync();
            }
            else
            {
                return (await repo.RetrieveAllAsync()).Where(album => album.ArtistId == ArtistId);
            }

        }
    }
}