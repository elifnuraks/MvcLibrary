using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;


namespace MvcLibrary.Controllers
{
    public class ProcessController : Controller
    {
        db_LibraryEntities db = new db_LibraryEntities();
        // GET: Process
        public ActionResult Index()
        {
            var values = db.tbl_Movements.Where(x => x.PROCESS == true).ToList();
            return View(values);
        }
    }
}