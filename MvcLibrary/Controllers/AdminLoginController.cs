using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibrary.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        db_LibraryEntities db = new db_LibraryEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_Admin p)
        {
            var information = db.tbl_Admin.FirstOrDefault(x => x.USER_NAME == p.USER_NAME && x.PASSWORD == p.PASSWORD);
            if(information != null)
            {
                FormsAuthentication.SetAuthCookie(information.USER_NAME, false);
                Session["USER_NAME"] = information.USER_NAME.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }
            
    }
}