using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Application.DTOs.AuthDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Domain.Entities.AuthEntities;
using SchoolManagementSystem.Infrastructure.Response;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
    public class UserAuthService(
        UserManager<ApplicationUser> _userManager,
        RoleManager<IdentityRole> _roleManager,
        SignInManager<ApplicationUser> signInManager,
        IJWTService jWTService) 
        : IUserAuthService
    {
        public async Task<ServiceResponse> CheckUserExistAsync(LoginDto userLoginDto)
        {

            var user = await _userManager.FindByNameAsync(userLoginDto.Username);
            if (user == null)
                return new ServiceResponse
                {
                    Data = null,
                    Message = "Username or password is incorrect",
                    StatusCode = 404,
                    Success = false
                };

            var checkPassword = await signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password,false);

            if(!checkPassword.Succeeded)
                return new ServiceResponse
                {
                    Data = null,
                    Message = "Username or password is incorrect",
                    StatusCode = 404,
                    Success = false
                };

            var token = await jWTService.GenerateJWTTokenAsync(user,_userManager);

            return new ServiceResponse
            {
                Data = token,
                Message = "Login Successfully",
                StatusCode = 200,
                Success = true
            };

        }

        public async Task<ServiceResponse> RegisterAsync(RegisterDto registerDto)
        {
            //Check if email already exists

            var existUser = await _userManager.FindByNameAsync(registerDto.Username);

            if (existUser != null)
                return new ServiceResponse
                {
                    Data = null,
                    Message = "User Already Exists",
                    StatusCode = 200,
                    Success = true
                };
            //check if the role already exists in database

            var role = await _roleManager.RoleExistsAsync(registerDto.role);

            if(!role)
                return new ServiceResponse
                {
                    Data = null,
                    Message = "Please choose the correct Role Name",
                    StatusCode = 200,
                    Success = true
                };

            // create user 

            var user = new ApplicationUser
            {
                CreateDate = DateTime.Now,
                Email = registerDto.Email,
                UserName = registerDto.Username,
                RoleName = registerDto.role.ToLower()
            };

            await _userManager.CreateAsync(user, registerDto.Password);

            await _userManager.AddToRoleAsync(user, registerDto.role);

            return new ServiceResponse
            {
                Data = null,
                Message = "User was added successfully",
                StatusCode = 200,
                Success = true
            };
        }
    }
}
