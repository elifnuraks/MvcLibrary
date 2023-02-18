using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Controllers
{
    public class MessagesController : Controller
    {
        db_LibraryEntities db = new db_LibraryEntities();
        // GET: Messages
        public ActionResult Index()
        {
            var membermail = (string)Session["Mail"].ToString();
            var messages = db.tbl_Messages.Where(x => x.BUYER == membermail.ToString()).ToList(); ;
         
            return View(messages);
        }
        public ActionResult Send()
        {
            var membermail = (string)Session["Mail"].ToString();
            var messages = db.tbl_Messages.Where(x => x.SENDER == membermail.ToString()).ToList(); ;

            return View(messages);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(tbl_Messages t)
        {
            var membermail = (string)Session["Mail"].ToString();
            t.SENDER = membermail.ToString();
            t.DATE = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tbl_Messages.Add(t);
            db.SaveChanges();
            return RedirectToAction("Send","Messages");
        }
        public PartialViewResult Partial()
        {

            var membermail = (string)Session["Mail"].ToString();
            var gelensayisi = db.tbl_Messages.Where(x => x.BUYER == membermail).Count();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = db.tbl_Messages.Where(x => x.SENDER == membermail).Count();
            ViewBag.d2 = gidensayisi;
            return PartialView();
        }
    }
}