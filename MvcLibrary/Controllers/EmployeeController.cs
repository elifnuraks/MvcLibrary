using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        db_LibraryEntities db = new db_LibraryEntities();
        public ActionResult Index()
        {
            var values = db.tbl_Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(tbl_Employees p)
        {
            if(!ModelState.IsValid)
            {
                return View("AddEmployee");
            }
            db.tbl_Employees.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeDelete(int ID)
        {
            var employee = db.tbl_Employees.Find(ID);
            db.tbl_Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeBring(int ID)
        {
            var prs = db.tbl_Employees.Find(ID);
            return View("EmployeeBring", prs);
        }
        public ActionResult EmployeeUpdate(tbl_Employees p)
        {
            var prs = db.tbl_Employees.Find(p.ID);
            prs.EMPLOYEE = p.EMPLOYEE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}