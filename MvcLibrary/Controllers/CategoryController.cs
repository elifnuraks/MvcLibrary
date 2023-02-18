using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        db_LibraryEntities db = new db_LibraryEntities();
        public ActionResult Index()
        {
            var values = db.tbl_Categories.Where(x => x.STATE==true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(tbl_Categories p)
        {
            p.STATE = true;
            db.tbl_Categories.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int ID)
        {
            var category = db.tbl_Categories.Find(ID);
            //db.tbl_Categories.Remove(category);
            category.STATE = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryBring(int ID)
        {
            var ctg = db.tbl_Categories.Find(ID);
            return View("CategoryBring",ctg);
        }
        public ActionResult CategoryUpdate(tbl_Categories p)
        {
            var ctg = db.tbl_Categories.Find(p.ID);
            ctg.NAME = p.NAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}