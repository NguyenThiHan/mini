using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBasic.Models;

namespace WebBasic.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        ManagerDbContext dbContext = new ManagerDbContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin userlogin)
        {
            var user = dbContext.UserLogins.Where(p => p.UserName == userlogin.UserName).FirstOrDefault();
            if (user != null)
            {
                if (user.PassWord == userlogin.PassWord)
                {
                    var employee = dbContext.Employees.Where(p => p.IdEmployee == user.IdEmployeee).FirstOrDefault();
                    var position = dbContext.Positions.Where(p => p.IdPosition == employee.IdPosition).FirstOrDefault();
                    if (position.NamePosition == "Direction")
                    {
                        return Redirect("Manager/PageManager");
                    }
                }
            }
            return View("Login");
        }

        public void GetPosition()
        {
            List<Position> posisions = dbContext.Positions.ToList();
            //1 doi tuong giu toan bo du lieu minh da truy van
            SelectList positionsList = new SelectList(posisions, "IdPosition", "NamePosition");
            //Giao tiep giua controller vs View
            ViewBag.PositionsList = positionsList;
        }

        [HttpGet]
        public ActionResult PageManager()
        {
            return View(dbContext.Employees.ToList());
        }

        [HttpGet]
        //[ActionName("Details")]
        public ActionResult DetailEmployee(String id)
        {
            //Employee employee = new Employee();
            // employee = dbContext.Employees.Where(p => p.IdEmployee == id).FirstOrDefault();
            //return View(employee);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            GetPosition();
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return RedirectToAction("PageManager");
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult EditEmployee(String id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = dbContext.Employees.Find(id);
            if(employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            if(ModelState.IsValid)
            {
                dbContext.Entry(employee).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("PageManager");
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult DeleteEmployee(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpDelete]
        public ActionResult DeleteEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(employee).State = EntityState.Deleted;
                dbContext.SaveChanges();
                return RedirectToAction("PageManager");
            }
            return View(employee);
        }

    }
}