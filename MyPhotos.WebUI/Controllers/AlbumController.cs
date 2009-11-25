using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MyPhotos.Core.Repository;
using MyPhotos.Core.Service;

namespace MyPhotos.WebUI.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumService _albumService;

        public AlbumController() : this(null)
        {
            
        }

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService ?? new AlbumService(new AlbumRepository());
        }

        //
        // GET: /Album/

        public ActionResult Index()
        {
            var album = _albumService.GetAll();

            if (album.Count < 1)
                RedirectToAction("Create");

            return View(album);
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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
            return View();
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
