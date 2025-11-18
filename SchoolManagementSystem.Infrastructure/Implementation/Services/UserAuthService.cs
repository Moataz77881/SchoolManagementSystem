using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Application.DTOs.AuthDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Response;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
    public class UserAuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJWTService jWTService) 
        : IUserAuthService
    {
        public async Task<ServiceResponse> CheckUserExistAsync(LoginDto userLoginDto)
        {

            var user = await userManager.FindByNameAsync(userLoginDto.Username);
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

            var token = await jWTService.GenerateJWTTokenAsync(user,userManager);

            return new ServiceResponse
            {
                Data = token,
                Message = "Login Successfully",
                StatusCode = 200,
                Success = true
            };

        }
    }
}
