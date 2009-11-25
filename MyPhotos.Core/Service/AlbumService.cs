using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MyPhotos.Core.Model;
using MyPhotos.Core.Repository;

namespace MyPhotos.Core.Service
{
    public interface IAlbumService
    {
        Album GetById(int id);
        List<Album> GetAll();
    }

    public class AlbumService : IAlbumService
    {
        protected IAlbumRepository _albumRespository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRespository = albumRepository ?? new AlbumRepository();
        }

        public Album GetById(int id)
        {
            Album album = null;

            try
            {
                album = _albumRespository.GetById(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return album;
        }

        public List<Album> GetAll()
        {
            var albums = new List<Album>();

            albums = _albumRespository.GetAll().ToList();

            return albums;
        }
    }
}