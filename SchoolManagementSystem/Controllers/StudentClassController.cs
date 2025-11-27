using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.StudentClassDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Helper;
using System.Reflection.Metadata.Ecma335;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentClassController(IStudentClassService _studentClassService) : ControllerBase
    {
        [HttpGet("ViewClasses")]
        public async Task<IActionResult> ViewAll() 
        {
            return this.ToActionResult(await _studentClassService.ViewEnrolledStudentClassServiceAsync());
        }
        
        [HttpPost("AssignStudentToClass")]
        public async Task<IActionResult> AssignStudentInClass(List<StudentClassRequestDto> studentClassRequestDtos)
        {
            return this.ToActionResult(await _studentClassService.AssignStudentToClassServiceAsync(studentClassRequestDtos));
        }
    }
}
