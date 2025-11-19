using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Interfaces.Repositories;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Helper;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentService _departmentService) : ControllerBase
    {
        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAll() 
        {
            return this.ToActionResult(await _departmentService.GetAllDepartmentServiceAsync());
        }
    }
}
