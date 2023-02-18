using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
using System.Web.Security;

namespace MvcLibrary.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        db_LibraryEntities db = new db_LibraryEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_Members p)
        {
            var informations = db.tbl_Members.FirstOrDefault(x => x.MAIL == p.MAIL &&
            x.PASSWORD == p.PASSWORD);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.MAIL, false);
                Session["Mail"] = informations.MAIL.ToString();
                //TempData["ID"] = informations.ID.ToString();
                //TempData["Name"] = informations.NAME.ToString();
                //TempData["Surname"] = informations.SURNAME.ToString();
                //TempData["Username"] = informations.USERNAME.ToString();
                //TempData["Password"] = informations.PASSWORD.ToString();
                //TempData["School"] = informations.SCHOOL.ToString();
                return RedirectToAction("Index", "Panel");
            }

            else
            {
                return View();
            }
            
        }
    }
}