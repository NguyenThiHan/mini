using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Service;


namespace WebMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Login(Employee employee)
        {
            var model = new IndexModel();

            //call API
            model.employees = await ApiService.GetAllEmployeeList();
            model.positions = await ApiService.GetAllPositionList();

            Employee item = model.employees.Where(p => p.EmployeeId == employee.EmployeeId).FirstOrDefault();
            if (item != null)
            {
                if (item.Password == employee.Password)
                {
                    return RedirectToAction("Index","Home");
                }
            }
            return View("Login");
        }
    }
}