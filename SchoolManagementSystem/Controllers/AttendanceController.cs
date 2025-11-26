using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.AttendanceDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Helper;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher")]
    public class AttendanceController: ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        [HttpGet("getbyclassid")]
        public async Task<IActionResult> getAll([FromQuery][Required] int classId) 
        {
            return this.ToActionResult(await _attendanceService.GetAllAttendanceServiceAsync(classId));
        }

        [HttpPost("markattendace")]
        public async Task<IActionResult> MarkAttendace([FromBody] List<AttendanceRequestDto> attendanceRequestDto)
        {
            return this.ToActionResult(await _attendanceService.MarkAttendanceServiceAsync(attendanceRequestDto));
        }
    }
}
