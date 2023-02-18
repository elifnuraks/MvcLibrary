using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        db_LibraryEntities db= new db_LibraryEntities();
        public ActionResult Index(string p)
        {
            var books = from k in db.tbl_Books select k;
            if(!string.IsNullOrEmpty(p))
            {
                books = books.Where(m => m.NAME.Contains(p));
            }
            //var books = db.tbl_Books.ToList();
            return View(books.ToList());
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> values = (from i in db.tbl_Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.value1 = values;
            List<SelectListItem> values2 = (from i in db.tbl_Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.NAME + ' ' + i.SURNAME,
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.value2 = values2;
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(tbl_Books p)
        {
            var ctg = db.tbl_Categories.Where(k => k.ID == p.tbl_Categories.ID).FirstOrDefault();
            var yzr = db.tbl_Authors.Where(y => y.ID == p.tbl_Authors.ID).FirstOrDefault();
            p.tbl_Categories = ctg;
            p.tbl_Authors = yzr;
            p.STATE = true;
            db.tbl_Books.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult BookDelete(int ID)
        {
            var book = db.tbl_Books.Find(ID);
            db.tbl_Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult BookBring(int id)
        {
            var ktp = db.tbl_Books.Find(id);
            List<SelectListItem> values = (from i in db.tbl_Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.value1 = values;
            List<SelectListItem> values2 = (from i in db.tbl_Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.NAME + ' ' + i.SURNAME,
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.value2 = values2;
            return View("BookBring", ktp);
        }
        public ActionResult BookUpdate(tbl_Books p)
        {
            var books = db.tbl_Books.Find(p.ID);
            books.NAME = p.NAME;
            books.PRINTYEAR = p.PRINTYEAR;
            books.PAGE = p.PAGE;
            books.PUBLISHER = p.PUBLISHER;
            books.STATE = true;
            var ctg = db.tbl_Categories.Where(k => k.ID == p.tbl_Categories.ID).FirstOrDefault();
            var yzr = db.tbl_Authors.Where(y => y.ID == p.tbl_Authors.ID).FirstOrDefault();
            books.CATEGORY = ctg.ID;
            books.AUTHOR = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}