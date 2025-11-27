using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.AssignmentDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Helper;
using System.Security.Claims;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(AuthenticationSchemes ="Bearer",Roles = "Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController(IAssingmentService _assingmentService) : ControllerBase
    {
        [HttpGet("getallassignmentbyclassid")]
        public async Task<IActionResult> getAllWithClassId([FromQuery] int pageNumber, [FromQuery] int pageSize) 
        {
            return this.ToActionResult(await _assingmentService.GetAssignmentsByClassIdServiceAsync(pageNumber,pageSize));
        }

        [HttpPost("createnewassignment")]
        public async Task<IActionResult> CreateNewAssignment([FromBody] List<AssignmentRequestDto> assignmentRequestDto)
        {
            return this.ToActionResult(await _assingmentService.CreateNewAssignmentServiceAsync(assignmentRequestDto));
        }
    }
}
