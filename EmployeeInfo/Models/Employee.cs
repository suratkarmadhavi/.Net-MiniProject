using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeInfo.Models
{
    public class Employee
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public Decimal Salary { get; set; }
    }
}