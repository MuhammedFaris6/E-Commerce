using E_Commerce.Domain.DTO;
using E_Commerce.Domain.Interface.IQueries;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastructure.Queries
{
    public class DepartmentQueries : IDepartmentQueries
    {
        private readonly ECommerceDbcontext dbcontext;

        public DepartmentQueries(ECommerceDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public DepartmentSalaryDTO GetSalary()
        {
            var result = (from employee in dbcontext.employees
                          join department in dbcontext.departments
                          on employee.DepartmentId equals department.DepartmentId
                          group employee by department.DepartmentName into g
                          select new DepartmentSalaryDTO
                          {
                              DepartmentName = g.Key,
                              AverageSalary = g.Average(e => e.Salary),
                              HighestSalary = g.Max(e => e.Salary),
                              LowestSalary = g.Min(e => e.Salary)
                          });




            return result.FirstOrDefault();

        }

    }
}
