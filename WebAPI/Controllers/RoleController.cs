using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private IRoleService _roleService;
        private IRoleDetailService _roleDetailService;

        
        public RoleController(IRoleService roleService, IRoleDetailService roleDetailService)
        {
            this._roleService=roleService;
            this._roleDetailService=roleDetailService;
        }

        [HttpGet]
        public IActionResult GetRoles() {
            List<RoleDetailModel> roles = _roleDetailService.ViewAll();
            return Ok(roles);
        }
    }
}
