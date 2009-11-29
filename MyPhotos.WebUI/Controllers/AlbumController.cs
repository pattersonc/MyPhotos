using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MyPhotos.Core.Model;
using MyPhotos.Core.Repository;
using MyPhotos.Core.Service;

namespace MyPhotos.WebUI.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumService _albumService;
        private IFileStoreService _fileStoreService;

        public AlbumController() : this(null, null)
        {
            
        }

        public AlbumController(IAlbumService albumService, IFileStoreService fileStoreService)
        {
            _albumService = albumService ?? new AlbumService(new AlbumRepository());
            _fileStoreService = fileStoreService ?? new FileStoreService();
        }

        //
        // GET: /Album/

        public ActionResult Index()
        {
            var albums = _albumService.GetAll();

            return View(albums);
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
        public ActionResult Create(Album album)
        {
            try
            {

                album.CreatedDate = DateTime.Now;
                album.ModifiedDate = DateTime.Now;

                _albumService.Add(album);
                _albumService.Save();

                return RedirectToAction("Edit", new { id=album.ID });
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
            var album = _albumService.GetById(id);

            if (album == null)
                return View("AlbumNotFound");

            return View(album);
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Album postedAlbum)
        {
            try
            {
                var album = _albumService.GetById(id);

                album.Name = postedAlbum.Name;

                int coverPhotoID = Convert.ToInt32(Request.Form["CoverPhotoID"]);

                var photo = album.Photos.Where(p => p.ID == coverPhotoID).Single();

                album.CoverPhoto = photo;

                _albumService.Save();

                return View(album);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddPhoto(int id)
        {
            try
            {
                string filePath = _fileStoreService.SaveNew(Request.Files[0].InputStream);

                string fileName = Path.GetFileName(filePath);
                string thumbnail = _fileStoreService.CreateThumbnail(fileName);

                var photo = new Photo()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "My new photo",
                    Filename = fileName,
                    ThumbFilename = thumbnail
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
    }
}
