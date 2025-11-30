using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using SchoolManagementSystem.Application.DTOs.SubmissionDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Response;
using System.Security.Claims;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
    public class SubmissionService(IUnitOfWork _unitOfWork, IHostEnvironment _hostEnvironment, IMapper _mapper,IHttpContextAccessor _httpContextAccessor) : ISubmissionService
    {
        public async Task<ServiceResponse> GradeStudentAssignment(int submissionId, SubmissionUpdateDto submissionUpdateDto)
        {
            var teacherId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var assignmnet = await _unitOfWork.AssignmentRepository.GetByIdFirstOrDefaultAsync(x => x.CreatedByTeacherId == teacherId);

            if (assignmnet == null)
                return new ServiceResponse 
                {
                    Data = null,
                    Message = "Assignment didnot create by this teacher",
                    StatusCode = 404,
                    Success = false
                };

            var submission = await _unitOfWork.SubmissionRepository.GetByIdAsync(submissionId);

            if(submission == null)
                return new ServiceResponse
                {
                    Data = null,
                    Message = "Submission doesnot Exist",
                    StatusCode = 404,
                    Success = false
                };

            submission.Grade = submissionUpdateDto.Grade;
            submission.Remarkes = submissionUpdateDto.Remarkes;
            submission.GradedByTeacherId = teacherId;

            await _unitOfWork.SaveAsync();
            return new ServiceResponse
            {
                Data = null,
                Message = "Submission Was Updated Successflly",
                StatusCode = 200,
                Success = true
            };

        }

        public async Task<ServiceResponse> SubmitAssignmentServiceAsync(SubmissionRequestDto submissionRequestDto)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var assignmentClassId = await _unitOfWork.AssignmentRepository.FirstOrDefaultWithSelectorAsync(
                selector: x => x.ClassId,
                Predecate: x => x.Id == submissionRequestDto.AssignmentId);

            if (assignmentClassId == 0)
                return new ServiceResponse 
                {
                    Data = null,
                    Message = $"the Assignment Id {submissionRequestDto.AssignmentId} doesnot Exist",
                    StatusCode = 404,
                    Success = false
                };

            var studentId = await _unitOfWork.StudentClassRepository.FirstOrDefaultWithSelectorAsync(selector: x => x.StudentId, Predecate: x => x.ClassId == assignmentClassId);

            if (userId != studentId)
                return new ServiceResponse 
                {
                    Data = null,
                    Message = "Student doesnot exist in this class",
                    StatusCode = 404,
                    Success = false
                };
            string rootPath = _hostEnvironment.ContentRootPath;
            string folderPath = Path.Combine(rootPath, "Uploads", "Assignments");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(submissionRequestDto.FileUrl.FileName)}";
            string filePath = Path.Combine(folderPath, fileName);

            var submissionModel = _mapper.Map<Submission>(submissionRequestDto);

            submissionModel.FileUrl = filePath;
            submissionModel.StudentId = userId;
            submissionModel.SubmittedDate = DateTime.Now;

            await _unitOfWork.SubmissionRepository.AddAsync(submissionModel);

            await _unitOfWork.SaveAsync();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await submissionRequestDto.FileUrl.CopyToAsync(stream);
            }

            return new ServiceResponse 
            {
                Data = null,
                Message = "Assignment Was Submited",
                StatusCode =200,
                Success = true
            };
        }

        public async Task<ServiceResponse> ViewSubmissionAssignmentServiceAsync()
        {
            var studentId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var submissions = await _unitOfWork.SubmissionRepository.GetAllWithSelectorAsync(
                selector: x => new SubmissionResponseDto
                {
                    AssignmentTitle = x.Assignment!.Title,
                    Grade = x.Grade,
                    Remarkes = x.Remarkes,
                    SubmittedDate = x.SubmittedDate,
                    TeacherName = x.Teacher!.UserName
                },Predecate: x=>x.StudentId == studentId);

            return new ServiceResponse
            {
                Data = submissions,
                Message = "Submissions was received Succssefully",
                StatusCode = 200,
                Success = true
            };
        }
    }
}

