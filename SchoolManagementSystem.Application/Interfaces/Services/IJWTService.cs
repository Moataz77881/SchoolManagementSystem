using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.Services
{
    public interface IJWTService
    {
        public Task<string> GenerateJWTTokenAsync(ApplicationUser user, UserManager<ApplicationUser> userManager);
    }
}
