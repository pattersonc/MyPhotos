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
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {

            return View();
        }

        [ActionName("Index")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add()
        {
            var fileStoreSvc = new FileStoreService();

            string filePath = fileStoreSvc.SaveNew(Request.Files[0].InputStream);

            string fileName = Path.GetFileName(filePath);

            var photo = new Photo()
                            {
                                CreatedDate = DateTime.Now,
                                ModifiedDate = DateTime.Now,
                                Description = "My new photo",
                                Filename = fileName,
                     
                            };

            var albumsvc = new AlbumService();

            var album = albumsvc.GetById(2);

            album.Photos.Add(photo);

            albumsvc.Save();



            return View();
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Test/Create

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
        // GET: /Test/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Test/Edit/5

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
