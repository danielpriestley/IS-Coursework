using Microsoft.EntityFrameworkCore.ChangeTracking;
using Coursework2.Shared;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookService.Repositories
{
    public class AlbumsRepository : IAlbumsRepository
    {
        // use a static thread-safe dictionary field to cache the albums
        private static ConcurrentDictionary
        <int, Album> albumsCache;
        // using an instanced data context field because it should not be cached due to their internal caching
        private ChinookDb db;
        public AlbumsRepository(ChinookDb db)
        {
            this.db = db;
            // pre-load the albums from the database as a normal dictionary with AlbumId as the key, then convert it to a thread-safe concurrent dictionary
            if (albumsCache == null)
            {
                albumsCache = new ConcurrentDictionary<int, Album>(
                    db.Albums.ToDictionary(a => a.AlbumId));
            }
        }
        public async Task<Album> CreateAsync(Album a)
        {
            EntityEntry<Album> added = await db.Albums.AddAsync(a);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                // if the album is new, add it to the cache, else call updateCache method
                return albumsCache.AddOrUpdate(a.AlbumId, a, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Album>> RetrieveAllAsync()
        {
            // for performance, get from cache
            return Task.Run<IEnumerable<Album>>(
                () => albumsCache.Values
            );
        }

        public Task<Album> RetrieveAsync(int id)
        {
            return Task.Run(() =>
            {
                // for performance get from cache
                Album a;
                albumsCache.TryGetValue(id, out a);
                return a;
            });
        }

        private Album UpdateCache(int id, Album a)
        {
            Album old;
            if (albumsCache.TryGetValue(id, out old))
            {
                if (albumsCache.TryUpdate(id, a, old))
                {
                    return a;
                }
            }
            return null;
        }

        public async Task<Album> UpdateAsync(int id, Album a)
        {

            // update in db
            db.Albums.Update(a);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                // if the album is new, add it to the cache, else call updateCache method
                return UpdateCache(id, a);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {

            // remove from database
            Album a = db.Albums.Find(id);
            db.Albums.Remove(a);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                // remove from cache
                return albumsCache.TryRemove(id, out a);
            }
            else
            {
                return null;
            }
        }
    }
}
