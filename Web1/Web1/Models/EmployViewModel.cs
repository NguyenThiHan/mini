using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Web1.Models
{
    public class EmployViewModel
    {
        public string EmployeeId { get; set; }

        public string SalaryId { get; set; }

        public string EmployeeFullName { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        public string DateOfBirth { get; set; }

        public string AddressHome { get; set; }

        public string HomeTown { get; set; }

        public string Gender { get; set; }

        public string IdentityCart { get; set; }

        public string AcountBank { get; set; }

        public string Password { get; set; }

        public decimal SalaryMoney { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentId { get; set; }

        public string PositionName { get; set; }
    }
}