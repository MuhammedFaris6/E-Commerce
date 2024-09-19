using E_Commerce.Domain.Interface.IQueries;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentQueries query;

        public DepartmentController(IDepartmentQueries query)
        {
            this.query = query;
        }
        [HttpGet]
        public IActionResult GetSalary()
        {
            var salary = query.GetSalary();
            return Ok(salary);
        }
    }
}
