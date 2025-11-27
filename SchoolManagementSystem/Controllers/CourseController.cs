using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using SchoolManagementSystem.Application.DTOs.CourseDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Helper;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class CourseController(ICourseService _courseService) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllCourses([FromQuery] string? courseCode) 
        {
            return this.ToActionResult(await _courseService.getAllCourseServiceAsync(courseCode));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCourse([FromBody] List<CourseRequestDto> courseRequestDto)
        {
            return this.ToActionResult(await _courseService.CreateCourseServiceAsync(courseRequestDto));
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdaetCourse([FromQuery] int courseId, [FromBody] CourseUpdateRequestDto courseUpdateRequestDto) 
        {
            return this.ToActionResult(await _courseService.UpdateCourseServiceAsync(courseId, courseUpdateRequestDto));
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> SoftDeleteCourse([FromBody] List<int> coursesId)
        {
            return this.ToActionResult(await _courseService.DeleteCourses(coursesId));
        }
    }
}
