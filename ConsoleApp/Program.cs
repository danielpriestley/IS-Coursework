using System;
using Coursework2.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Chinook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Chinook Music");

            var db = new ChinookDb();

            IQueryable<Album> album = db.Albums;

            foreach (Album a in album)
            {
                Console.WriteLine($"{a.AlbumId}. {a.Title} {a.ArtistId}");

            }

            Console.WriteLine($"Press any key to exit");
            Console.ReadKey();


        }
    }
}
