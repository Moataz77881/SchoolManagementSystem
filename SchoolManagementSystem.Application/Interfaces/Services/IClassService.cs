using SchoolManagementSystem.Application.DTOs.ClassDto;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.Services
{
    public interface IClassService
    {
        Task<ServiceResponse> GetAllClassesServiceAsync(int pageNumber,int pageSize);
        Task<ServiceResponse> CreateClassesServiceAsync(List<ClassRequestDto> classrequestDtos);
        Task<ServiceResponse> UpdateClassesServiceAsync(int id ,ClassUpdateRequestDtos classrequestDtos);
        Task<ServiceResponse> deactivateClassesServiceAsync(List<int> ids);

    }
}
