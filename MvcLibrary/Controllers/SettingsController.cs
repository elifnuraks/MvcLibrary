using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        db_LibraryEntities db = new db_LibraryEntities();
        public ActionResult Index()
        {
            var users = db.tbl_Admin.ToList();
            return View(users);
        }
        public ActionResult Index2()
        {
            var users = db.tbl_Admin.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult NewAdmin()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(tbl_Admin t)
        {
            db.tbl_Admin.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminDelete(int ID)
        {
            var admin = db.tbl_Admin.Find(ID);
            db.tbl_Admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult AdminUpdate(int ID)
        {
            var admin = db.tbl_Admin.Find(ID);
            return View("AdminUpdate", admin);
        }
        [HttpPost]
        public ActionResult AdminUpdate(tbl_Admin p)
        {
            var admin = db.tbl_Admin.Find(p.ID);
            admin.USER_NAME= p.USER_NAME;
            admin.PASSWORD= p.PASSWORD;
            admin.AUTHORIZATION= p.AUTHORIZATION;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

    }
}