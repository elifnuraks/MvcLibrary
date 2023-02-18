using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Controllers
{
    public class StatisticsController : Controller
    {
        db_LibraryEntities db = new db_LibraryEntities();
        // GET: Statistics
        public ActionResult Index()
        {
            var values1 = db.tbl_Members.Count();
            var values2 = db.tbl_Books.Count();
            var values3 = db.tbl_Books.Where(x => x.STATE ==false).Count();
            var values4 = db.tbl_Penalties.Sum(x => x.MONEY);
            ViewBag.dgr1 = values1;
            ViewBag.dgr2 = values2;
            ViewBag.dgr3 = values3;
            ViewBag.dgr4 = values4;
            return View();
        }
        public ActionResult Weather()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult WeatherCard()
        {
            return View();
        }
        public ActionResult Uploadapicture(HttpPostedFileBase filee)
        {
            if (filee.ContentLength > 0)
            {
                string filepath = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(filee.FileName));
                filee.SaveAs(filepath);
            }
            return RedirectToAction("Gallery");
        }
        public ActionResult LinqCard()
        {
            return View();
        }
    }
}
