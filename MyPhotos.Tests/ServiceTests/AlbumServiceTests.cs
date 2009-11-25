using System;
using System.Collections.Generic;
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

            var albums = new List<Album>();

            for (int i = 1; i <= 100; i++ )
            {
                var album = new Album()
                                {
                                    ID = i,
                                    CreatedDate = DateTime.Now.AddDays(-i),
                                    ModifiedDate = DateTime.Now.AddSeconds(-i),
                                    Name = "Album #" + i
                                };

                albums.Add(album);
            }

            mockAlbumRepo.Setup(p => p.GetAll()).Returns(albums);

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
    }
}