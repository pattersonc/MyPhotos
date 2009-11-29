using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyPhotos.Core.Model;
using MyPhotos.Core.Service;
using MyPhotos.WebUI.Controllers;
using System;

namespace MyPhotos.Tests.ControllerTests
{
    
    [TestClass]
    public class AlbumControllerTests
    {
        private IFileStoreService _fileStoreService;

        private List<Album> _albums;

        public AlbumControllerTests()
        {
            _albums = new List<Album>();

            for (int i = 1; i <= 5; i++)
            {
                var album = new Album()
                                {
                                    ID = i

                                };

                _albums.Add(album);
            }

            var mockFileStoreService = new Mock<IFileStoreService>();
            _fileStoreService = mockFileStoreService.Object;

        }

        [TestMethod]
        public void Index_Should_Return_5_Albums()
        {
            var mockAlbumSvc = new Mock<IAlbumService>();
            mockAlbumSvc.Setup(p => p.GetAll()).Returns(_albums);

            var albumController = new AlbumController(mockAlbumSvc.Object, null);

            var result = albumController.Index() as ViewResult;

            var model = result.ViewData.Model as IEnumerable<Album>;
            Assert.AreEqual(5, model.Count());
        }

        [TestMethod]
        public void Create_Should_Add_Album_To_Repository()
        {
            var mockAlbumSvc = new Mock<IAlbumService>();
            mockAlbumSvc.Setup(p => p.Add(It.IsAny<Album>())).Verifiable("Add must be called.");
            mockAlbumSvc.Setup(p => p.Save()).Verifiable("Save must be called.");

            var albumController = new AlbumController(mockAlbumSvc.Object, _fileStoreService);

            var album = new Album()
                            {
                                Name = "Photo Album",
                                ID = 999
                            };

            var result = albumController.Create(album);

            mockAlbumSvc.VerifyAll();
        }

        [TestMethod]
        public void Create_Should_Redirect_To_Edit_After_Add()
        {
            var mockAlbumSvc = new Mock<IAlbumService>();

            var albumController = new AlbumController(mockAlbumSvc.Object, _fileStoreService);

            var album = new Album()
            {
                Name = "Photo Album",
                ID = 999
            };

            var result = albumController.Create(album) as RedirectToRouteResult;

            Assert.AreEqual("Edit", result.RouteValues["action"]);
            Assert.AreEqual(999, result.RouteValues["id"]);

        }

        [TestMethod]
        public void Edit_Should_Return_Album_That_Is_Not_Null()
        {
            var mockAlbumSvc = new Mock<IAlbumService>();
            mockAlbumSvc.Setup(p => p.GetById(It.IsAny<int>())).Returns( _albums[0] );

            var albumController = new AlbumController(mockAlbumSvc.Object, _fileStoreService);

            var result = albumController.Edit(1) as ViewResult;

            Assert.IsNotNull(result.ViewData.Model);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(Album));
            
        }


    }
}