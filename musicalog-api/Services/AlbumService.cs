using Musical.Data.Data;
using Musical.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musical.Services
{
    public class AlbumService : IAlbumService
    {
        readonly MusicalogContext _dbContext;
        public AlbumService(MusicalogContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbcontext");
        }
        public void CreateAlbum(Album album)
        {
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
        }

        public void DeleteAlbum(int id)
        {
            _dbContext.Albums.Remove(new Album
            {
                Id = id
            });
            _dbContext.SaveChanges();
        }

        public Album GetAlbum(int id)
        {
            return _dbContext.Albums.SingleOrDefault(a => a.Id == id);
        }

        public IList<Album> GetAllAlbums()
        {
            return _dbContext.Albums.ToList();
        }

        public void UpdateAlbum(Album album)
        {
            _dbContext.Albums.Update(album);
            _dbContext.SaveChanges();
        }
    }
}
