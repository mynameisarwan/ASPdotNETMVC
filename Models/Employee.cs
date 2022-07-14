using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETMVC.Models
{
    public class Employee
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        public string EmployeeId { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "Datetime")]
        public DateTime HireDate { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        public Decimal Salary { get; set; }
    }
}
