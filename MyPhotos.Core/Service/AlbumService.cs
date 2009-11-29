using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MyPhotos.Core.Model;
using MyPhotos.Core.Repository;

namespace MyPhotos.Core.Service
{
<<<<<<< HEAD

=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
    public interface IAlbumService
    {
        Album GetById(int id);
        List<Album> GetAll();
<<<<<<< HEAD
        void Add(Album album);
        void Save();
        Photo GetNextPhoto(Photo photo);
        Photo GetPreviousPhoto(Photo photo);
=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
    }

    public class AlbumService : IAlbumService
    {
        protected IAlbumRepository _albumRespository;

<<<<<<< HEAD
        public AlbumService() : this(null) {}

=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
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
<<<<<<< HEAD

        public void Add(Album album)
        {
            _albumRespository.Add(album);
        }

        public void Save()
        {
            _albumRespository.Save();
        }

        public Photo GetNextPhoto(Photo photo)
        {
            try
            {
                var index = photo.Album.Photos.IndexOf(photo);

                return photo.Album.Photos.Skip(index + 1).Take(1).Single();

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Photo GetPreviousPhoto(Photo photo)
        {
            try
            {
                var index = photo.Album.Photos.IndexOf(photo);

                if (index <= 0)
                    return null;

                return photo.Album.Photos.Skip(index -1).Take(1).Single();

            }
            catch (Exception)
            {
                return null;
            }
        }

=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
    }
}