using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    [AllowAnonymous]
    public class SignUpController : Controller
    {
        
        db_LibraryEntities db = new db_LibraryEntities();
        // GET: SignUp

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_Members p)
        {
            if(!ModelState.IsValid)
            {
                return View("Login");
            }
            db.tbl_Members.Add(p);
            db.SaveChanges();
            return View();
            
        }
    }
}