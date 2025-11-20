using SchoolManagementSystem.Application.DTOs.DepartmentDTOs;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        public Task<ServiceResponse> GetAllDepartmentServiceAsync();
        public Task<ServiceResponse> CreateDepartmentsServiceAsync(List<DepartmentCreateRequestDto> departmentDto);
        public Task<ServiceResponse> UpdateDepartmentServiceAsync(int DepartmentId, DepartmentUpdateRequestDto departmentDto);
        public Task<ServiceResponse> DeleteDepartmentServiceAsync(int DepartmentId);

	}
}
