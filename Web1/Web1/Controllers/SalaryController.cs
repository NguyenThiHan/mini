using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Models;
using Web1.Service;

namespace Web1.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary

        [HttpGet]
        [Route("Index")]
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var model = new IndexModel();
            model.salaries = await ApiService.GetAllSalary();
            return View(model);
        }

        [HttpGet]
        [Route("DetailSalary")]
        public async System.Threading.Tasks.Task<ActionResult> DetailSalary(String id)
        {
            var model = new IndexModel();
            model.salary = await ApiService.GetSalary(id);
            return View(model);
        }

        [HttpGet]
        [Route("EditSalary")]
        public async System.Threading.Tasks.Task<ActionResult> EditSalary(String id)
        {
            var model = new IndexModel();
            model.salary = await ApiService.GetSalary(id);
            return View(model);
        }


        [HttpPost]
        [Route("EditSalary")]
        public async System.Threading.Tasks.Task<ActionResult> EditSalary(String id,Salary salary)
        {
            var model = new IndexModel();
            if (ModelState.IsValid)
            {
                model.salaries = await ApiService.PutSalaryAsync(id,salary);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("CreateSalary")]
        public ActionResult CreateSalary()
        {
            //List<Salary> salaries = await ApiService.GetAllSalary();
            //GetSalary();
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateSalary(Salary salary)
        {
            var model = new IndexModel();
            if (ModelState.IsValid)
            {
                model.salaries = await ApiService.PostSalaryAsync(salary);
                return RedirectToAction("Index");
            }
            return View(model);
            // var model = new IndexModel();
        }


        [HttpDelete]
        [Route("DeleteSalary")]
        public async System.Threading.Tasks.Task<ActionResult> DeleteSalary(String id)
        {
            var model = new IndexModel();
            model.salary = await ApiService.GetSalary(id);
            if (model.salary != null)
            {
                try
                {
                    model.salaries = await ApiService.DeleteSalaryAsync(id);
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.enrror = "Khong the xoa duoc!";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}