using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Service;
using Web1.Models;

namespace Web1.Controllers
{
    public class HomeController : Controller
    {
        //home/Index
        [HttpGet]
        [Route("Index")]
       public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var model = new IndexModel();
            //call API
            model.employees = await ApiService.GetAllEmployee();
            model.salaries = await ApiService.GetAllSalary();
            List<Employee> listNhanVien = model.employees;
            List<Salary> listSalary = model.salaries;
            ViewBag.listEmployee = (from x in listNhanVien
                         join y in listSalary on x.SalaryId equals y.SalaryId
                         select new EmployViewModel()
                         {
                             EmployeeId = x.EmployeeId,
                             DateOfBirth = x.DateOfBirth,
                             EmployeeFullName = x.EmployeeFullName,
                             AddressHome = x.AddressHome,
                             HomeTown = x.HomeTown,
                             Gender = x.Gender,
                             IdentityCart = x.IdentityCart,
                             Password = x.Password,
                             SalaryMoney = y.SalaryMoney,
                             AcountBank = x.AcountBank
                         }).ToList();
            return View();
        }


        [HttpGet]
        [Route("DetailsEmployee")]
        public async System.Threading.Tasks.Task<ActionResult> DetailsEmployee(string id)
        {
            var model = new IndexModel();
            model.employee = await ApiService.GetEmployee(id);
            return View(model.employee);

            // var model = new IndexModel();
        }

        public async void GetSalary()
        {
            List<Salary> salaries = await ApiService.GetAllSalary();
            SelectList salaryList = new SelectList(salaries, "SalaryId", "SalaryMoney");
            ViewBag.SalaryList = salaryList;
        }
        
        [HttpGet]
        [Route("CreateEmployee")]
        public ActionResult CreateEmployee()
        {
            //List<Salary> salaries = await ApiService.GetAllSalary();
            //GetSalary();
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateEmployee(Employee employee)
        {
            var model = new IndexModel();
            if(ModelState.IsValid)
            {
                model.employees = await ApiService.PostEmployeesAsync(employee);
                return RedirectToAction("Index");
            }
            return View(model);
            // var model = new IndexModel();
        }

        [HttpGet]
        [Route("EditEmployee")]
        public async System.Threading.Tasks.Task<ActionResult> EditEmployee(string id)
        {
            var model = new IndexModel();
            model.employee = await ApiService.GetEmployee(id);
            return View(model.employee);
            // var model = new IndexModel();
        }

        [HttpPost]
        [Route("EditEmployee")]
        public async System.Threading.Tasks.Task<ActionResult> EditEmployee(String id,Employee employee)
        {
            var model = new IndexModel();
            if (ModelState.IsValid)
            {
                model.employees = await ApiService.PutEmployeesAsync(id, employee);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpDelete]
        [Route("Deletemployee")]
        public async System.Threading.Tasks.Task<ActionResult> DeleteEmployee(string id)
        {
            var model = new IndexModel();
            model.employee = await ApiService.GetEmployee(id);
            if(model.employee != null)
            {
                try
                {
                    model.employees = await ApiService.DeleteEmployeesAsync(id);
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.enrror = "Khong the xoa duoc!";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
            // var model = new IndexModel();
        }

    }
}