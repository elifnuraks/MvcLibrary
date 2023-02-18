using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibrary.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        db_LibraryEntities db = new db_LibraryEntities();
        // GET: Panel
        [HttpGet]

        public ActionResult Index()
        {
            var membermail = (string)Session["Mail"];
            //var values = db.tbl_Members.FirstOrDefault(z => z.MAIL == membermail);
            var values = db.tbl_Announcement.ToList();
            var d1 = db.tbl_Members.Where(x => x.MAIL == membermail).Select(y => y.NAME).FirstOrDefault();
            var d2 = db.tbl_Members.Where(x => x.MAIL == membermail).Select(y => y.SURNAME).FirstOrDefault();
            var d3 = db.tbl_Members.Where(x => x.MAIL == membermail).Select(y => y.IMAGE).FirstOrDefault();
            var d4 = db.tbl_Members.Where(x => x.MAIL == membermail).Select(y => y.USERNAME).FirstOrDefault();
            var d5 = db.tbl_Members.Where(x => x.MAIL == membermail).Select(y => y.SCHOOL).FirstOrDefault();
            var d6 = db.tbl_Members.Where(x => x.MAIL == membermail).Select(y => y.TELEPHONE).FirstOrDefault();
            var d7 = db.tbl_Members.Where(x => x.MAIL == membermail).Select(y => y.MAIL).FirstOrDefault();
            var memberID = db.tbl_Members.Where(x => x.MAIL == membermail).Select(y => y.ID).FirstOrDefault();
            var d8 = db.tbl_Movements.Where(x => x.MEMBER == memberID).Count();
            var d9 = db.tbl_Messages.Where(x => x.BUYER == membermail).Count();
            var d10 = db.tbl_Announcement.Count();
            ViewBag.d1 = d1;
            ViewBag.d2 = d2;
            ViewBag.d3 = d3;
            ViewBag.d4 = d4;
            ViewBag.d5 = d5;
            ViewBag.d6 = d6;
            ViewBag.d7 = d7;
            ViewBag.d8 = d8;
            ViewBag.d9 = d9;
            ViewBag.d10 = d10;
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(tbl_Members p)
        {
            var user = (string)Session["Mail"];
            var member = db.tbl_Members.FirstOrDefault(x => x.MAIL == user);
            member.PASSWORD = p.PASSWORD;
            member.NAME = p.NAME;
            member.IMAGE = p.IMAGE;
            member.SCHOOL = p.SCHOOL;
            member.USERNAME = p.USERNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MyBooks()
        {
            var user = (string)Session["Mail"];
            var id = db.tbl_Members.Where(x => x.MAIL == user.ToString()).Select(z => z.ID).FirstOrDefault();
            var values = db.tbl_Movements.Where(x => x.MEMBER == id).ToList();
            return View(values);
        }
        
        public ActionResult Announcement()
        {
            var announcementlist = db.tbl_Announcement.ToList();
            return View(announcementlist);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
        public PartialViewResult Partial()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var user = (string)Session["Mail"];
            var ID = db.tbl_Members.Where(x => x.MAIL == user).Select(y => y.ID).FirstOrDefault();
            var findmember = db.tbl_Members.Find(ID);
            return PartialView("Partial2",findmember);
        }
    }
}