using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Models;
using Web1.Service;
using System.Windows.Forms;


namespace Web1.Controllers
{
    public class DepartmentController : Controller
    {
        public object MessageBox { get; private set; }

        // GET: Department
        [HttpGet]
        [Route("Index")]
        public async System.Threading.Tasks.Task<ActionResult> Index()
         {
            var model = new IndexDepartment();

            model.departments= await ApiService.GetAllDepartment();
            return View(model);
        }

        //GET:
        [HttpGet]
        [Route("DetailsDepartment")]
        public async System.Threading.Tasks.Task<ActionResult> DetailsDepartment(String id)
        {
            var model = new IndexDepartment();
            model.department = await ApiService.GetDepartment(id);
            return View(model);
        }

        //GET
        [HttpGet]
        [Route("EditDepartment")]
        public async System.Threading.Tasks.Task<ActionResult> EditDepartment(String id)
        {
            var model = new IndexDepartment();
            model.department = await ApiService.GetDepartment(id);
            return View(model);
        }

        [HttpPost]
        [Route("EditDepartment")]
        public async System.Threading.Tasks.Task<ActionResult> EditDepartment(String id,Department department)
        {
            var model = new IndexDepartment();

            if (ModelState.IsValid)
            {
                model.departments = await ApiService.PutDepartmentsAsync(id, department);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        [Route("CreateDepartment")]
        public ActionResult CreateDepartment()
        {
            //List<Salary> salaries = await ApiService.GetAllSalary();
            //GetSalary();
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateDepartment(Department department)
        {
            var model = new IndexDepartment();
            if (ModelState.IsValid)
            {
                model.departments = await ApiService.PostDepartmentAsync(department);
                return RedirectToAction("Index");
            }
            return View(model);
            // var model = new IndexModel();
        }


        //GET
        [HttpGet]
        [Route("DeleteDepartment")]
        public async System.Threading.Tasks.Task<ActionResult> DeleteDepartment(String id)
        {
            var model = new IndexDepartment();
            model.department = await ApiService.GetDepartment(id);

            if(model.department != null)
            {
                try
                {
                    model.departments = await ApiService.DeleteDepartmentAsync(id);
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