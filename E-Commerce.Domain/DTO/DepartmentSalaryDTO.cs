namespace E_Commerce.Domain.DTO
{
    public class DepartmentSalaryDTO
    {
        public string DepartmentName { get; set; }
        public decimal AverageSalary { get; set; }
        public decimal HighestSalary { get; set; }
        public decimal LowestSalary { get; set; }
    }
}
