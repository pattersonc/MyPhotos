using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MyPhotos.Core.Model;
using MyPhotos.Core.Service;
using MyPhotos.Core.Util;
using MyPhotos.WebUI.ViewModel;

namespace MyPhotos.WebUI.Controllers
{
    public class PhotoController : Controller
    {
        private IPhotoService _photoService;
        private IAlbumService _albumService;

        public PhotoController() : this(null, null)
        {
        }

        public PhotoController(IPhotoService photoService, IAlbumService albumService)
        {
            _photoService = photoService ?? new PhotoService();
            _albumService = albumService ?? new AlbumService();
        }
        //
        // GET: /Photo/5

        public ActionResult Index(long id)
        {
            var photo = _photoService.GetById(id);
            var nextPhoto = _albumService.GetNextPhoto(photo);
            var prevPhoto = _albumService.GetPreviousPhoto(photo);

            var model = new PhotoDetailViewModel(photo, nextPhoto, prevPhoto);

            return View(model);
        }

        //
        // GET: /Photo/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Photo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Photo photo)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
