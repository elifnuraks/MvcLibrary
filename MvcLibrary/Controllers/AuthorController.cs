using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        db_LibraryEntities db=new db_LibraryEntities();
        public ActionResult Index()
        {
            var values = db.tbl_Authors.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        public ActionResult AddAuthor(tbl_Authors p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAuthor");
            }
            db.tbl_Authors.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorDelete(int ID)
        {
            var author = db.tbl_Authors.Find(ID);
            db.tbl_Authors.Remove(author);
            db.SaveChanges();   
            return RedirectToAction("Index");
        }
        public ActionResult AuthorBring(int ID)
        {
            var aut = db.tbl_Authors.Find(ID);  
            return View("AuthorBring",aut);
        }
        public ActionResult AuthorUpdate(tbl_Authors p )
        {
            var aut = db.tbl_Authors.Find(p.ID);
            aut.NAME = p.NAME;
            aut.SURNAME = p.SURNAME;
            aut.DETAIL = p.DETAIL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorBook(int ID)
        {
            var author = db.tbl_Books.Where(x => x.AUTHOR == ID).ToList();
            var yzrad = db.tbl_Authors.Where(y => y.ID == ID).Select(z => z.NAME + " " + z.SURNAME).FirstOrDefault();
            ViewBag.y1 = yzrad;
            return View(author);
        }
    }
}