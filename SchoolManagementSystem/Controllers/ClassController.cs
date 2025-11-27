using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.ClassDto;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Helper;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer",Roles ="Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController(IClassService _classService) : ControllerBase
    {
        [HttpGet("getAll")]
        public async Task<IActionResult> Get([FromQuery] int pageNumber, [FromQuery] int PageSize) 
        {
            return this.ToActionResult(await _classService.GetAllClassesServiceAsync(pageNumber, PageSize));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] List<ClassRequestDto> classRequestDtos) 
        {
            return this.ToActionResult(await _classService.CreateClassesServiceAsync(classRequestDtos));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] int classId,[FromBody] ClassUpdateRequestDtos classRequestDtos)
        {
            return this.ToActionResult(await _classService.UpdateClassesServiceAsync(classId,classRequestDtos));
        }
        [HttpPut("deactivate")]
        public async Task<IActionResult> Deactivate([FromBody] List<int> classesId)
        {
            return this.ToActionResult(await _classService.deactivateClassesServiceAsync(classesId));
        }
    }
}
