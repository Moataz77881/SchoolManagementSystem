using AutoMapper;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Application.DTOs.AssignmentDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
    public class AssignmentService(IHttpContextAccessor _httpContextAccessor,IUnitOfWork _unitOfWork,IMapper _mapper) : IAssingmentService
    {
        public async Task<ServiceResponse> CreateNewAssignmentServiceAsync(List<AssignmentRequestDto> assignmentRequestDto)
        {
            var teacherId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var assignmentmodel = _mapper.Map <List<Assignment>>(assignmentRequestDto);
            foreach (var assignment in assignmentmodel) 
            {
                var teacherClass = await _unitOfWork.ClassRepository.GetAllWithFilterAsync(Predecate: x => x.TeacherId == teacherId && x.Id == assignment.ClassId);
                if(teacherClass.Count == 0)
                    return new ServiceResponse
                    {
                        Data = null,
                        Message = $"Teacher not assigned in this class id {assignment.ClassId}",
                        StatusCode = 404,
                        Success = true
                    };
                assignment.CreatedByTeacherId = teacherId; 
            }

            await _unitOfWork.AssignmentRepository.AddRangeAsync(assignmentmodel);
            await _unitOfWork.SaveAsync();
            return new ServiceResponse 
            {
                Data = null,
                Message = "Assignments Was Added successfully",
                StatusCode = 200,
                Success = true
            };
        }

        public async Task<ServiceResponse> GetAssignmentsByClassIdServiceAsync(int pageNumber, int pageSize)
        {
            var teacherId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var classId = await _unitOfWork.ClassRepository.GetAllWithSelectorAsync(selector: x=>x.Id ,Predecate: x => x.TeacherId == teacherId);

            var assignments = await _unitOfWork.AssignmentRepository.GetAllWithSelectorAndPaginationAsync(
                pageNumber: pageNumber,
                pageSize: pageSize,
                selector: x => new AssignmentResponseDto
                {
                    ClassName = x.Class!.Name,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description,
                    DueDate = x.DueDate,
                    Title = x.Title,
                    TeacherName = x.ApplicationUser!.UserName!
                },
                Predecate: x => classId.Contains(x.ClassId));

            return new ServiceResponse
            {
                Data = assignments,
                Message = "Assignments Was Received successfully",
                StatusCode = 200,
                Success = true
            };
        }
    }
}
