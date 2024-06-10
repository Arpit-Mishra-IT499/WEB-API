using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;

        }
        [HttpGet]
        public IActionResult getDepartments()
        {
            List<DepartmentModel> departments = _departmentService.ViewAll();
            return Ok(departments);
        }
    }
}
