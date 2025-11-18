using SchoolManagementSystem.Application.DTOs.AuthDTOs;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.Services
{
    public interface IUserAuthService
    {
        public Task<ServiceResponse> CheckUserExistAsync(LoginDto userLoginDto);
    }
}
