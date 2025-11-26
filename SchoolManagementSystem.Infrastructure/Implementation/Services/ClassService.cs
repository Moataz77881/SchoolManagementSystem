using AutoMapper;
using SchoolManagementSystem.Application.DTOs.ClassDto;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
    public class ClassService(IUnitOfWork _unitOfWork, IMapper _mapper) : IClassService
    {
        public async Task<ServiceResponse> CreateClassesServiceAsync(List<ClassRequestDto> classrequestDtos)
        {
            var Classes = _mapper.Map<List<Class>>(classrequestDtos);
            await _unitOfWork.ClassRepository.AddRangeAsync(Classes);
            await _unitOfWork.SaveAsync();
            return new ServiceResponse
            {
                Data = null,
                Message = "Classes was added successfully",
                StatusCode = 200,
                Success = true
            };

        }

        public async Task<ServiceResponse> deactivateClassesServiceAsync(List<int> ids)
        {
            await _unitOfWork.ClassRepository.Deactivate(ids);
            await _unitOfWork.SaveAsync();
            return new ServiceResponse
            {
                Data = null,
                Message = "Classes was Deactivated successfully",
                StatusCode = 200,
                Success = true
            };
        }

        public async Task<ServiceResponse> GetAllClassesServiceAsync(int pageNumber, int pageSize)
        {
            var classes = await _unitOfWork.ClassRepository.GetAllWithSelectorAndPaginationAsync(
                Predecate: x => x.IsActive == false
                , selector:
                s => new ClassResponseDto
                {
                    Course = s.Course!.Name,
                    CreatedDate = s.CreatedDate,
                    EndDate = s.EndDate,
                    IsActive = s.IsActive,
                    Name = s.Name,
                    Semester = s.Semester,
                    StartDate = s.StartDate,
                    TeacherName = s.ApplicationUser!.UserName!,
                    UpdatedDate = s.UpdatedDate
                }, pageNumber: pageNumber, pageSize: pageSize);

            return new ServiceResponse
            {
                Data = classes,
                Message = "Data was Received successfully",
                StatusCode = 200,
                Success = true

            };
        }

        public async Task<ServiceResponse> UpdateClassesServiceAsync(int id, ClassUpdateRequestDtos classRequestDtos)
        {
            var classModel = await _unitOfWork.ClassRepository.GetByIdAsync(id);

            if (classRequestDtos.TeacherId is not null)
                classModel.TeacherId = classRequestDtos.TeacherId;

            if (classRequestDtos.CourseId is not null)
                classModel.CourseId = classRequestDtos.CourseId ?? 0;

            if (classRequestDtos.Semester is not null)
                classModel.Semester = classRequestDtos.Semester ?? 0;

            if (classRequestDtos.Name is not null)
                classModel.Name = classRequestDtos.Name;

            classModel.StartDate = classRequestDtos.StartDate;
            classModel.EndDate = classRequestDtos.EndDate;

            classModel.UpdatedDate = DateTime.Now;

            await _unitOfWork.SaveAsync();

            return new ServiceResponse
            {
                Data = null,
                Message = "Class was updated successfully",
                StatusCode = 200,
                Success = true
            };

        }
    }
}
