using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class IndexModel
    {
        public String Title { get; set; }

        public List<Employee> employees { get; set; }

        public List<Department> departments { get; set; }

        public List<Position> positions { get; set; }
        public List<Salary> salaries { get; set; }

        public IndexModel()
        {
            employees = new List<Employee>();
            departments = new List<Department>();
            positions = new List<Position>();
            salaries = new List<Salary>();

        }
    }
}