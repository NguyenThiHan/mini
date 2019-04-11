using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web1.Models
{
    public class IndexDepartment
    {
        public Department department;

        //public Employee employee;


        public List<Department> departments;

        public IndexDepartment()
        {
            departments = new List<Department>();
        }
    }
}