using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.DepartmentDTOs;
using SchoolManagementSystem.Application.Interfaces.Repositories;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Helper;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentService _departmentService) : ControllerBase
    {

        [AllowAnonymous]
        [HttpGet("department/getAll")]
        public async Task<IActionResult> GetAll() 
        {
            return this.ToActionResult(await _departmentService.GetAllDepartmentServiceAsync());
        }

        [AllowAnonymous]
        [HttpPost("department/create")]
		public async Task<IActionResult> CreateDepartments([FromBody] List<DepartmentCreateRequestDto> departmentDtos)
		{
			return this.ToActionResult(await _departmentService.CreateDepartmentsServiceAsync(departmentDtos));
		}

        [AllowAnonymous]
        [HttpPut("department/update")]
		public async Task<IActionResult> UpdateDepartment([FromQuery] int departmentId, [FromBody] DepartmentUpdateRequestDto departmentDto)
		{
			return this.ToActionResult(await _departmentService.UpdateDepartmentServiceAsync(departmentId,departmentDto));
		}

        [AllowAnonymous]
        [HttpDelete("department/delete")]
		public async Task<IActionResult> deleteDepartment([FromQuery] int departmentId)
		{
			return this.ToActionResult(await _departmentService.DeleteDepartmentServiceAsync(departmentId));
		}
	}
}
