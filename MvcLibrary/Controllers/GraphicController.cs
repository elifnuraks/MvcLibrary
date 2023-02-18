using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MvcLibrary.Models;

namespace MvcLibrary.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeBookResult()
        {
            return Json(list());
        }
        public List<Class1> list()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                publisher = "Güneş",
                number = 7
            });
            cs.Add(new Class1()
            {
                publisher = "Yıldız",
                number = 4
            });
            cs.Add(new Class1()
            {
                publisher = "Ay",
                number = 6
            });

            return cs;

        }
    }
}