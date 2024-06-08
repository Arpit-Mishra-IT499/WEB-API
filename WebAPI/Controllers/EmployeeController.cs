using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public ActionResult getAllEmployee()
        {
            List<EmployeeModel> employee =_employeeService.ViewAll();
            return Ok(employee);
        }

    }
}
