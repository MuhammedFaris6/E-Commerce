using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? department { get; set; }
    }

}
