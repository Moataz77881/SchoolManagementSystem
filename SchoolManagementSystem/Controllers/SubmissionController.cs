using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.SubmissionDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Helper;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController(ISubmissionService _submissionService) : ControllerBase
    {
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer",Roles ="Student")]
        [HttpPost("Submit")]
        public async Task<IActionResult> SubmitAssignment(SubmissionRequestDto submissionRequestDto) 
        {
            return this.ToActionResult(await _submissionService.SubmitAssignmentServiceAsync(submissionRequestDto));
        }
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [HttpGet("ViewSubmissions")]
        public async Task<IActionResult> ViewSubmissions()
        {
            return this.ToActionResult(await _submissionService.ViewSubmissionAssignmentServiceAsync());
        }
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Teacher")]
        [HttpPut("UpdateGrade")]
        public async Task<IActionResult> Update([FromQuery] int submissionId, [FromBody] SubmissionUpdateDto submissionUpdateDto)
        {
            return this.ToActionResult(await _submissionService.GradeStudentAssignment(submissionId,submissionUpdateDto));
        }
    }
}
