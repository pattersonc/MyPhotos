using System;
<<<<<<< HEAD
using System.Data.Linq;
using System.Collections.Generic;
using System.Linq;
=======
using System.Collections.Generic;
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyPhotos.Core.Model;
using MyPhotos.Core.Repository;
using MyPhotos.Core.Service;

namespace MyPhotos.Tests.ServiceTests
{
    [TestClass]
    public class AlbumServiceTests
    {
        private IAlbumRepository _albumRepository;
        
        private const int ValidId = 1;
        private const int InvalidId = 2;
        private const int ExceptionId = 3;
<<<<<<< HEAD
        private List<Album> _albums;

=======
        
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
        public AlbumServiceTests()
        {
            var mockAlbumRepo = new Mock<IAlbumRepository>();
            mockAlbumRepo.Setup(p => p.GetById(ValidId)).Returns(new Album()
                                                                     {
                                                                        ID = ValidId,
                                                                        CreatedDate = DateTime.Now.AddDays(-1),
                                                                        Name = "My Album with ID 1",
                                                                        ModifiedDate = DateTime.Now.AddMinutes(-30)
                                                                     });
            mockAlbumRepo.Setup(p => p.GetById(InvalidId)).Returns((Album)null);
            mockAlbumRepo.Setup(p => p.GetById(ExceptionId)).Throws(new Exception("Repo exception"));

<<<<<<< HEAD
            _albums = new List<Album>();
=======
            var albums = new List<Album>();
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba

            for (int i = 1; i <= 100; i++ )
            {
                var album = new Album()
                                {
                                    ID = i,
                                    CreatedDate = DateTime.Now.AddDays(-i),
                                    ModifiedDate = DateTime.Now.AddSeconds(-i),
<<<<<<< HEAD
                                    Name = "Album #" + i,
                                    Photos = new List<Photo>()
                                };


                for (int j = 0; j < 51; j++)
                {
                    var photo = new Photo()
                                    {
                                        Album = album,
                                        CreatedDate = DateTime.Now.AddMinutes(-i),
                                        ModifiedDate = DateTime.Now.AddMinutes(-i),
                                        Description = "Album #" + i +" Photo #" + j,
                                        Filename = "album" + i + "photo" + j + ".jpg",
                                        ID = j
                                    };

                    album.Photos.Add(photo);
                }

                _albums.Add(album);
            }

            mockAlbumRepo.Setup(p => p.GetAll()).Returns(_albums);
=======
                                    Name = "Album #" + i
                                };

                albums.Add(album);
            }

            mockAlbumRepo.Setup(p => p.GetAll()).Returns(albums);
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba

            _albumRepository = mockAlbumRepo.Object;
        }

        [TestMethod]
        public void GetById_with_valid_id_returns_not_null()
        {
            var albumSvc = new AlbumService(_albumRepository);

            Assert.IsNotNull(albumSvc.GetById(ValidId));
        }

        [TestMethod]
        public void GetById_with_invalid_id_returns_null()
        {
            var albumSvc = new AlbumService(_albumRepository);

            Assert.IsNull(albumSvc.GetById(InvalidId));
        }

        [TestMethod]
        public void GetById_with_exception_thrown_by_repo_returns_null()
        {
            var albumSvc = new AlbumService(_albumRepository);

            Assert.IsNull(albumSvc.GetById(ExceptionId));
        }

        [TestMethod]
        public void GetAll_returns_not_null()
        {
            var albumSvc = new AlbumService(_albumRepository);

            Assert.IsNotNull(albumSvc.GetAll());
        }

        [TestMethod]
        public void GetAll_returns_100_albums()
        {
            var albumSvc = new AlbumService(_albumRepository);

            Assert.AreEqual(100, albumSvc.GetAll().Count);
        }
<<<<<<< HEAD

        [TestMethod]
        public void GetNextPhoto_returns_not_null()
        {
            var mockAlbumRepo = new Mock<IAlbumRepository>();
            mockAlbumRepo.Setup(p => p.GetById(It.IsAny<int>())).Returns( _albums.Where(p => p.ID == 50).Single() );

            var albumSvc = new AlbumService(mockAlbumRepo.Object);

            var album = albumSvc.GetById(50);

            var photo = album.Photos.ElementAt(25);

            var nextPhto = albumSvc.GetNextPhoto(photo);

            Assert.IsNotNull(nextPhto);
            Assert.AreEqual(26, nextPhto.ID);
        }

        [TestMethod]
        public void GetPreviousPhoto_returns_not_null()
        {
            var mockAlbumRepo = new Mock<IAlbumRepository>();
            mockAlbumRepo.Setup(p => p.GetById(It.IsAny<int>())).Returns(_albums.Where(p => p.ID == 50).Single());

            var albumSvc = new AlbumService(mockAlbumRepo.Object);

            var album = albumSvc.GetById(50);

            var photo = album.Photos.ElementAt(25);

            var prevPhoto = albumSvc.GetPreviousPhoto(photo);

            Assert.IsNotNull(prevPhoto);
            Assert.AreEqual(24, prevPhoto.ID);
        }
=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
    }
}