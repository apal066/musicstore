using Musical.Entity.Models;
using System.Collections.Generic;

namespace Musical.Services
{
    public interface IAlbumService
    {
        Album GetAlbum(int id);
        void CreateAlbum(Album album);
        void DeleteAlbum(int id);
        IList<Album> GetAllAlbums();
        void UpdateAlbum(Album album);
    }
}
