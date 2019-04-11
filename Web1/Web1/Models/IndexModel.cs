using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web1.Models
{
    public class IndexModel
    {
        public Employee employee;
        public Position position;
        public Salary salary;
        public Department department;
        public List<Employee> employees { get; set; }
        public List<Position> positions { get; set; }
        public List<Salary> salaries { get; set; }
        public List<Department> departments { get; set; }

        public IndexModel()
        {
            employees = new List<Employee>();
            salaries = new List<Salary>();
            positions = new List<Position>();
            departments = new List<Department>();
        
        }
    }
}