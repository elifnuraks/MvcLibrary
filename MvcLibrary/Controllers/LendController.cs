using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;


namespace MvcLibrary.Controllers
{
    [Authorize(Roles = "A")]
    public class LendController : Controller
    {
        db_LibraryEntities db = new db_LibraryEntities();
        
        // GET: Loaned
        public ActionResult Index()
        {
            var values = db.tbl_Movements.Where(x => x.PROCESS == false).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult LendMe()
        {
            List<SelectListItem> value1 = (from x in db.tbl_Members.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.NAME + " " + x.SURNAME,
                                               Value = x.ID.ToString(),

                                           }).ToList();
            List<SelectListItem> value2 = (from y in db.tbl_Books.Where(x => x.STATE == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.NAME,
                                               Value = y.ID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from z in db.tbl_Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.EMPLOYEE,
                                               Value = z.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = value1;
            ViewBag.dgr2 = value2;
            ViewBag.dgr3 = value3;
            return View();
        }

        [HttpPost]
        public ActionResult LendMe(tbl_Movements p)
        {
            var d1 = db.tbl_Members.Where(x => x.ID == p.tbl_Members.ID).FirstOrDefault();
            var d2 = db.tbl_Books.Where(y => y.ID == p.tbl_Books.ID).FirstOrDefault();
            var d3 = db.tbl_Employees.Where(z => z.ID == p.tbl_Employees.ID).FirstOrDefault();
            p.tbl_Members = d1;
            p.tbl_Books = d2;
            p.tbl_Employees= d3;
            db.tbl_Movements.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnTheBook(tbl_Movements p)
        {
            var odn = db.tbl_Movements.Find(p.ID);
            DateTime d1 = DateTime.Parse(odn.RETURN_DATE.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr  = d3.TotalDays;
            return View("ReturnTheBook", odn);
        }
        public ActionResult LendUpdate(tbl_Movements p)
        {
            var hrk = db.tbl_Movements.Find(p.ID);
            hrk.RECEIVED_DATE = p.RECEIVED_DATE;
            hrk.PROCESS = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}