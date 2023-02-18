using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace MvcLibrary.Controllers
{
    public class MemberController : Controller
    {
        db_LibraryEntities db = new db_LibraryEntities();
        // GET: Member
        public ActionResult Index(int sayfa=1)
        {
            // var values = db.tbl_Members.ToList();
            var values = db.tbl_Members.ToList().ToPagedList(sayfa, 3);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(tbl_Members p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMember");
            }
            db.tbl_Members.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemberDelete(int ID)
        {
            var member = db.tbl_Members.Find(ID);
            db.tbl_Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemberBring(int ID)
        {
            var uye = db.tbl_Members.Find(ID);
            return View("MemberBring", uye);
        }
        public ActionResult MemberUpdate(tbl_Members p)
        {
            var uye = db.tbl_Members.Find(p.ID);
            uye.NAME = p.NAME;
            uye.SURNAME = p.SURNAME;
            uye.MAIL = p.MAIL;
            uye.USERNAME = p.USERNAME;
            uye.PASSWORD = p.PASSWORD;
            uye.SCHOOL = p.SCHOOL;
            uye.TELEPHONE= p.TELEPHONE;
            uye.IMAGE= p.IMAGE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemberBookHistory(int ID)
        {
            var ktpgcms = db.tbl_Movements.Where(x => x.MEMBER == ID).ToList();
            var uyekit = db.tbl_Members.Where(y => y.ID == ID).Select(z => z.NAME + " " + z.SURNAME).FirstOrDefault();
            ViewBag.u1 = uyekit;
            return View(ktpgcms);
        }
    }
}