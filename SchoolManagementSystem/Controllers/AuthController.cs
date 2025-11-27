using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.AuthDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Helper;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserAuthService _userAuthService) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto) 
        {
            return this.ToActionResult(await _userAuthService.CheckUserExistAsync(loginDto));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            return this.ToActionResult(await _userAuthService.RegisterAsync(registerDto));
        }
    }
}
