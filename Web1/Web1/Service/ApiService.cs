using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web1.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;


namespace Web1.Service
{
    public class ApiService
    {
        static HttpClient client = new HttpClient();

        //get all employee in table
        public static async Task<List<Employee>> GetAllEmployee()
        {
            List<Employee> listEmployee = new List<Employee>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Employee/GetAllEmployee");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listEmployee = JsonConvert.DeserializeObject<List<Employee>>(content);
            }
            return listEmployee;
        }

       //get 1 employee 
        public static async Task<Employee> GetEmployee(string id)
        {
            Employee employee = new Employee();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Employee/GetEmployee/?id="+id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                employee = JsonConvert.DeserializeObject<Employee>(content);
            }
            return employee;
        }

        //post employee
        public static async Task<List<Employee>> PostEmployeesAsync(Employee employee)
        {
            List<Employee> listemployee;
            string stringData = JsonConvert.SerializeObject(employee);

            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/api/Employee/PostEmployee", contentData);
            response.EnsureSuccessStatusCode();
            //return response.Headers.Location;

            var content = await response.Content.ReadAsStringAsync();
            listemployee = JsonConvert.DeserializeObject<List<Employee>>(content);

            return listemployee;
        }

        //Put employee
        public static async Task<List<Employee>> PutEmployeesAsync(string employeeId, Employee employee)
        {
            string stringData = JsonConvert.SerializeObject(employee);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(
                $"https://localhost:5001/api/Employee/PutEmployee/?id=" + employeeId, contentData);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var listemployee = JsonConvert.DeserializeObject<List<Employee>>(content);
            return listemployee;
        }

        //Delete employee

        public static async Task<List<Employee>> DeleteEmployeesAsync(string employeeId)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:5001/api/Employee/DeleteEmployee/?id=" +employeeId );
            //list_product = await response.Content.ReadAsAsync<List<Product>>();
            var content = await response.Content.ReadAsStringAsync();
            var listemployee = JsonConvert.DeserializeObject<List<Employee>>(content);
            return listemployee;
        }

        //==================DEPARTMENT==========================================================================
        //get all info department
        public static async Task<List<Department>> GetAllDepartment()
        {
            List<Department> listDepartment = new List<Department>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Department/GetAllDepartment");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listDepartment = JsonConvert.DeserializeObject<List<Department>>(content);
            }
            return listDepartment;
        }

        //get 1 department
        public static async Task<Department> GetDepartment(string id)
        {
            Department department = new Department();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Department/GetDepartment/?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                department = JsonConvert.DeserializeObject<Department>(content);
            }
            return department;
        }
        //post department
        public static async Task<List<Department>> PostDepartmentAsync(Department department)
        {
            List<Department> listDepartment;
            string stringData = JsonConvert.SerializeObject(department);

            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/api/Department/PostDepartment", contentData);
            response.EnsureSuccessStatusCode();
            //return response.Headers.Location;

            var content = await response.Content.ReadAsStringAsync();
            listDepartment = JsonConvert.DeserializeObject<List<Department>>(content);

            return listDepartment;
        }

        //put department
        public static async Task<List<Department>> PutDepartmentsAsync(string departmentId, Department department)
        {
            string stringData = JsonConvert.SerializeObject(department);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(
                $"https://localhost:5001/api/Department/PutDepartment/?id=" + departmentId, contentData);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var listDepartment = JsonConvert.DeserializeObject<List<Department>>(content);
            return listDepartment;
        }
        //delete department
        public static async Task<List<Department>> DeleteDepartmentAsync(string departmentId)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:5001/api/Department/DeleteDepartment/?id=" + departmentId);
            //list_product = await response.Content.ReadAsAsync<List<Product>>();
            var content = await response.Content.ReadAsStringAsync();
            var listDepartment = JsonConvert.DeserializeObject<List<Department>>(content);
            return listDepartment;

        }


        //===========================POSITION==============================
        //get all position
        public static async Task<List<Position>> GetAllPosition()
        {
            List<Position> listPosition = new List<Position>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/position/GetAllPosition");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listPosition = JsonConvert.DeserializeObject<List<Position>>(content);
            }
            return listPosition;
        }

        //Get 1 position
        //api/position/GetPosition/?employeeid=NV01&departmentid=PB01

        public static async Task<Position> GetPosition(string employeeid,string departmentid)
        {
            Position position = new Position();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/position/GetPosition/?employeeid="+employeeid + "&departmentid="+departmentid);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                position = JsonConvert.DeserializeObject<Position>(content);
            }
            return position;
        }

        //post Position
        public static async Task<List<Position>> PostPositionAsync(Position position)
        {
            List<Position> listPosition;
            string stringData = JsonConvert.SerializeObject(position);

            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/api/position/PostAllPosition", contentData);
            response.EnsureSuccessStatusCode();
            //return response.Headers.Location;

            var content = await response.Content.ReadAsStringAsync();
            listPosition = JsonConvert.DeserializeObject<List<Position>>(content);

            return listPosition;
        }

        //put Position
        public static async Task<List<Position>> PutPositionAsync(string employeeid, string departmentid, Position position)
        {
            List<Position> listPosition =new List<Position>();

            string stringData = JsonConvert.SerializeObject(position);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(
                $"https://localhost:5001/api/position/PutPosition/"+ employeeid+"/"+ departmentid, contentData);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            listPosition = JsonConvert.DeserializeObject<List<Position>>(content);
            return listPosition;
        }

        //delete Position
        public static async Task<List<Position>> DeletePositionAsync(string employeeid, string departmentid)
        {
            List<Position> listPosition = new List<Position>();
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:5001/api/position/DeletePosition/"+employeeid+"/"+departmentid);
            //list_product = await response.Content.ReadAsAsync<List<Product>>();
            var content = await response.Content.ReadAsStringAsync();
            listPosition = JsonConvert.DeserializeObject<List<Position>>(content);
            return listPosition;

        }

        //========================SALARY===================================
        //get all salary
        public static async Task<List<Salary>> GetAllSalary()
        {
            List<Salary> listSalary = new List<Salary>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Salary/GetAllSalary");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listSalary = JsonConvert.DeserializeObject<List<Salary>>(content);
            }
            return listSalary;
        }

        //Get 1 salary
        public static async Task<Salary> GetSalary(string salaryId)
        {
            Salary salary = new Salary();
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/salary/GetSalary/?id=" + salaryId);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                salary = JsonConvert.DeserializeObject<Salary>(content);
            }
            return salary;
        }

        //Post Salary
        public static async Task<List<Salary>> PostSalaryAsync(Salary salary)
        {
            List<Salary> listSalary=new List<Salary>();

            string stringData = JsonConvert.SerializeObject(salary);

            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/api/salary/PostSalary", contentData);
            response.EnsureSuccessStatusCode();
            //return response.Headers.Location;

            var content = await response.Content.ReadAsStringAsync();
            listSalary = JsonConvert.DeserializeObject<List<Salary>>(content);

            return listSalary;
        }

        //Put Salary
      
        public static async Task<List<Salary>> PutSalaryAsync(string salaryId, Salary salary)
        {
            List<Salary> listSalary = new List<Salary>();

            string stringData = JsonConvert.SerializeObject(salary);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(
                $"https://localhost:5001/api/salary/PutSalary/?id=" +salaryId, contentData);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            listSalary = JsonConvert.DeserializeObject<List<Salary>>(content);
            return listSalary;
        }

        //Delete Salary
        public static async Task<List<Salary>> DeleteSalaryAsync(string salaryId)
        {
            List<Salary> listSalary = new List<Salary>();

            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:5001/api/salary/DeleteSalary/?id="+ salaryId);
            //list_product = await response.Content.ReadAsAsync<List<Product>>();
            var content = await response.Content.ReadAsStringAsync();
            listSalary = JsonConvert.DeserializeObject<List<Salary>>(content);
            return listSalary;
        }
    }
}