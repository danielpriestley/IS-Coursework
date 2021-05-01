using Coursework2.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChinookService.Repositories
{
    public interface IAlbumsRepository
    {
        Task<Album> CreateAsync(Album a);
        Task<IEnumerable<Album>> RetrieveAllAsync();
        Task<Album> RetrieveAsync(int id);
        Task<Album> UpdateAsync(int id, Album a);
        Task<bool?> DeleteAsync(int id);
    }
}