using SchoolManagementSystem.Application.DTOs.CourseDTOs;
using SchoolManagementSystem.Application.DTOs.DepartmentDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
    public class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
    {
        public async Task<ServiceResponse> GetAllDepartmentServiceAsync()
        {
            var res = await _unitOfWork.DepartmentRepository.GetAllWithSelectorAsync(
                d => new DepartmentDto
                {

                    CreatedDare = d.CreatedDare,
                    Name = d.Name,
                    Description = d.Description,
                    HeadOfDepartmentName = d.ApplicationUser!.UserName!,
                    UpdateDate = d.UpdateDate,
                    Courses = d.Courses!.Select(
                        c => new CourseDto
                        {
                            code = c.code,
                            CreatedDate = c.CreatedDate,
                            Credits = c.Credits,
                            Name = c.Name,
                            UpdatedDate = c.UpdatedDate
                        }).ToList()
                });
            return new ServiceResponse
            {
                Data = res.ToList(),
                Message = "Data was Recieved Successfully",
                StatusCode = 200,
                Success = true
            };
        }
    }
}
