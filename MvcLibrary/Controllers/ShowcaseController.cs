using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
using MvcLibrary.Models.MyClasses;

namespace MvcLibrary.Controllers
{
    public class ShowcaseController : Controller
    {
        db_LibraryEntities db = new db_LibraryEntities();
        // GET: Showcase

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.value1 = db.tbl_Books.ToList();
            cs.value2 = db.tbl_About.ToList();
            //var values = db.tbl_Books.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(tbl_Communication t)
        {
            db.tbl_Communication.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}