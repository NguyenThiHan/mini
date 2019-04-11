using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace WebMVC.Service
{
    public class ApiService
    {
        static HttpClient client = new HttpClient();
        public static async Task<List<Employee>> GetAllEmployeeList()
        {
            List<Employee> listEmployee = new List<Employee>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Manager/GetAllEmployee");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listEmployee = JsonConvert.DeserializeObject<List<Employee>>(content);

            }
            return listEmployee;
        }

        public static async Task<List<Department>> GetAllDepartmentList()
        {
            List<Department> listDepartment = new List<Department>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Manager/GetAllDepartment");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listDepartment = JsonConvert.DeserializeObject<List<Department>>(content);
            }
            return listDepartment;
        }

        public static async Task<List<Salary>> GelAllSalaryList()
        {
            List<Salary> listSalary = new List<Salary>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Manager/GetAllSalary");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listSalary = JsonConvert.DeserializeObject<List<Salary>>(content);
            }
            return listSalary;
        }

        public static async Task<List<Position>> GetAllPositionList()
        {
            List<Position> listPosition = new List<Position>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Manager/GetAllPosition");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listPosition = JsonConvert.DeserializeObject<List<Position>>(content);
            }
            return listPosition;
        }
    }
}