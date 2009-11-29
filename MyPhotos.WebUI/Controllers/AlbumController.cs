using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
<<<<<<< HEAD
using MyPhotos.Core.Model;
=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
using MyPhotos.Core.Repository;
using MyPhotos.Core.Service;

namespace MyPhotos.WebUI.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumService _albumService;
<<<<<<< HEAD
        private IFileStoreService _fileStoreService;

        public AlbumController() : this(null, null)
=======

        public AlbumController() : this(null)
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
        {
            
        }

<<<<<<< HEAD
        public AlbumController(IAlbumService albumService, IFileStoreService fileStoreService)
        {
            _albumService = albumService ?? new AlbumService(new AlbumRepository());
            _fileStoreService = fileStoreService ?? new FileStoreService();
=======
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService ?? new AlbumService(new AlbumRepository());
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
        }

        //
        // GET: /Album/

        public ActionResult Index()
        {
<<<<<<< HEAD
            var albums = _albumService.GetAll();

            return View(albums);
=======
            var album = _albumService.GetAll();

            if (album.Count < 1)
                RedirectToAction("Create");

            return View(album);
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
        }

        //
        // GET: /Album/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Album/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Album/Create

        [HttpPost]
<<<<<<< HEAD
        public ActionResult Create(Album album)
        {
            try
            {

                album.CreatedDate = DateTime.Now;
                album.ModifiedDate = DateTime.Now;

                _albumService.Add(album);
                _albumService.Save();

                return RedirectToAction("Edit", new { id=album.ID });
=======
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Album/Edit/5
 
        public ActionResult Edit(int id)
        {
<<<<<<< HEAD
            var album = _albumService.GetById(id);

            if (album == null)
                return View("AlbumNotFound");

            return View(album);
=======
            return View();
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
<<<<<<< HEAD
        public ActionResult Edit(int id, Album album)
        {
            try
            {
                var savedAlbum = _albumService.GetById(id);

                savedAlbum.Name = album.Name;

                _albumService.Save();

                return View(savedAlbum);
=======
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
            }
            catch
            {
                return View();
            }
        }
<<<<<<< HEAD

        [HttpPost]
        public ActionResult AddPhoto(int id)
        {
            try
            {
                string filePath = _fileStoreService.SaveNew(Request.Files[0].InputStream);

                string fileName = Path.GetFileName(filePath);

                var photo = new Photo()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "My new photo",
                    Filename = fileName,
                };

                var album = _albumService.GetById(id);

                album.Photos.Add(photo);

                _albumService.Save();

                return RedirectToAction("Edit", new {id = id});
            }
            catch (Exception)
            {
                
                throw;
            }

        }
=======
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
    }
}
