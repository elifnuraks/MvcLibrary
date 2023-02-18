using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Controllers
{
    public class AnnouncementController : Controller
    {
        db_LibraryEntities db = new db_LibraryEntities();

        // GET: Announcement
        public ActionResult Index()
        {
            var values = db.tbl_Announcement.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewAnnouncement()
        {
            return View();
        }
        public ActionResult NewAnnouncement(tbl_Announcement t)
        {
            db.tbl_Announcement.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAnnouncement(int ID)
        {
            var Announcement = db.tbl_Announcement.Find(ID);
            db.tbl_Announcement.Remove(Announcement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AnnouncementDetail(tbl_Announcement p)
        {
            var Announcement = db.tbl_Announcement.Find(p.ID);
            return View("AnnouncementDetail", Announcement);
        }
        public ActionResult AnnouncementUpdate(tbl_Announcement t)
        {
            var Announcement = db.tbl_Announcement.Find(t.ID);
            Announcement.CATEGORY = t.CATEGORY;
            Announcement.CONTENTS = t.CONTENTS;
            Announcement.DATE = t.DATE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}