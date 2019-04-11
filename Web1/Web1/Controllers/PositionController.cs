using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Models;
using Web1.Service;


namespace Web1.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var model = new IndexModel();
            //call API
            model.employees = await ApiService.GetAllEmployee();
            model.positions = await ApiService.GetAllPosition();
            model.departments = await ApiService.GetAllDepartment();

            List<Employee> listemployees = model.employees;
            List<Position> listpositions = model.positions;
            List<Department> listdepartments = model.departments;

            ViewBag.positions = (from x in listpositions
                                    join y in listemployees
                                    //join z in listdepartments
                                    on x.EmployeeId equals y.EmployeeId
                                    join z in listdepartments on x.DepartmentId equals z.DepartmentId
                                    select new EmployViewModel()
                                    {
                                        EmployeeId=x.EmployeeId,
                                        DepartmentId=x.DepartmentId,
                                        DepartmentName = z.DepartmentName,
                                        EmployeeFullName = y.EmployeeFullName,
                                        PositionName =x.PositionName
                                    }).ToList();
            return View();
        }
        //api/position/GetPosition/?employeeid=NV01&departmentid=PB01

        [HttpGet]
        [Route("DetailsPosition")]
        public async System.Threading.Tasks.Task<ActionResult> DetailsPosition(string empId, string depaId)
        {
            var model = new IndexModel();

            model.employees = await ApiService.GetAllEmployee();
            model.departments = await ApiService.GetAllDepartment();
            model.position = await ApiService.GetPosition(empId, depaId);

            List<Employee> listemployees = model.employees;
            List<Department> listdepartments = model.departments;
            Position position = model.position;


            ViewBag.positions =(from x in listemployees
                                 from y in listdepartments
                                 where x.EmployeeId==position.EmployeeId && y.DepartmentId==position.DepartmentId
                                 select new EmployViewModel()
                                 {
                                    EmployeeId=position.EmployeeId,
                                    DepartmentId=position.DepartmentId,
                                    DepartmentName=y.DepartmentName,
                                    EmployeeFullName=x.EmployeeFullName,
                                    PositionName=position.PositionName
                                 }).FirstOrDefault();
            return View();
        }

        [HttpGet]
        [Route("DetailsPosition")]
        public async System.Threading.Tasks.Task<ActionResult> EditPosition(string empId, string depaId)
        {
            var model = new IndexModel();

            model.employees = await ApiService.GetAllEmployee();
            model.departments = await ApiService.GetAllDepartment();
            model.position = await ApiService.GetPosition(empId, depaId);

            List<Employee> listemployees = model.employees;
            List<Department> listdepartments = model.departments;
            Position position = model.position;


            ViewBag.positions = (from x in listemployees
                                 from y in listdepartments
                                 where x.EmployeeId == position.EmployeeId && y.DepartmentId == position.DepartmentId
                                 select new EmployViewModel()
                                 {
                                     EmployeeId = position.EmployeeId,
                                     DepartmentId = position.DepartmentId,
                                     DepartmentName = y.DepartmentName,
                                     EmployeeFullName = x.EmployeeFullName,
                                     PositionName = position.PositionName
                                 }).FirstOrDefault();
            return View();
        }





        /// <summary>
        /// 
        /// </summary>
        //public async void GetEmployee()
        //{
        //    List<Employee> employees = await ApiService.GetAllEmployee();
        //    SelectList emlployeelist = new SelectList(employees, "EmployeeId", "EmployeeFullName");
        //    ViewBag.employees = emlployeelist;
        //}

        //private async void GetDepartment()
        //{
        //    List<Department> departments = await ApiService.GetAllDepartment();
        //    SelectList departmentlist = new SelectList(departments, "DepartmentId", "DepartmentName");
        //    ViewBag.departments =departmentlist;
        //}

        //private async void GetPosition()
        //{
        //    List<Position> positions = await ApiService.GetAllPosition();
        //    SelectList positionlist = new SelectList(positions, "PositionName", "PositionName");
        //    ViewBag.positions = positionlist;
        //}

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> AddPosition()
        {
            List<Employee> employees = await ApiService.GetAllEmployee();
            SelectList emlployeelist = new SelectList(employees, "EmployeeId", "EmployeeFullName");
            ViewBag.employees = emlployeelist;

            List<Department> departments = await ApiService.GetAllDepartment();
            SelectList departmentlist = new SelectList(departments, "DepartmentId", "DepartmentName");
            ViewBag.departments = departmentlist;

            List<Position> positions = await ApiService.GetAllPosition();

            SelectList positionlist = new SelectList(positions.Distinct(), "PositionName", "PositionName");
            ViewBag.positions = positionlist.Distinct();

            //ViewBag.positions = (from x in positions
            //                     select new EmployViewModel
            //                     {
            //                         PositionName = x.PositionName,
            //                     }).ToList().Distinct();
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> AddPosition(Position position)
        {
            var model = new IndexModel();
            if (ModelState.IsValid)
            {
                model.positions = await ApiService.PostPositionAsync(position);
                return RedirectToAction("Index");
            }
            return View(model);
            // var model = new IndexModel();
        }


    }
}