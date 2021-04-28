// This file contains the server-side C# code used by the Index.cshtml file
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Coursework2.Shared;
using System.Linq;


namespace Chinook.App
{
    public class AlbumsModel : PageModel
    {
        public string Heading1 { get; set; }

        public IEnumerable<string> Albums { get; set; }

        public void OnGet()
        {
            Heading1 = "Albums on Chinooks Label";
            // Albums = new[] { "1. Impacts", "2. Fires", "3. Night in the Wood" };

            // Instance of the albums class which connects to the chinook.db
            ChinookDb db = new ChinookDb();

            Albums = db.Albums.Select(a => a.AlbumId.ToString() + ". " + a.Title + ". " + a.ArtistId.ToString());

        }
    }
}