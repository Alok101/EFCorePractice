using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFGetStarted.Practice
{
    public class GeneratedValues
    {

    }
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [ConcurrencyCheck]
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
    public class EmployeeSalaryNew
    {
        [Key]
        public int EmpId { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal HRA { get; set; }

        public decimal TotalSalary { get; set; }
    }
}
