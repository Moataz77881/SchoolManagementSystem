using AutoMapper;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Application.DTOs.CourseDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Response;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
    public class CourseService(IUnitOfWork _unitOfWork, IMapper _mapper) : ICourseService
	{
        public async Task<ServiceResponse> CreateCourseServiceAsync(List<CourseRequestDto> courseRequestDto)
        {
			var coursesModel = _mapper.Map<List<Course>>(courseRequestDto);
			await _unitOfWork.CourseRepository.AddRangeAsync(coursesModel);
			await _unitOfWork.SaveAsync();
			return new ServiceResponse
            {
                Data = null,
                Message = "Courses Was Added successfully",
                StatusCode = 200,
                Success = true
            };

        }

        public async Task<ServiceResponse> DeleteCourses(List<int> courseId)
        {
			await _unitOfWork.CourseRepository.SoftDelete(courseId);

			await _unitOfWork.SaveAsync();

            return new ServiceResponse
            {
                Data = null,
                Message = "Courses Was Deleted successfully",
                StatusCode = 200,
                Success = true
            };

        }

        public async Task<ServiceResponse> getAllCourseServiceAsync(string? courseCode)
		{
			IEnumerable<CourseResponseDto> courseResponseDtos = new List<CourseResponseDto>() ;
			if (courseCode is not null)
			{
				courseResponseDtos = await _unitOfWork.CourseRepository.GetAllWithSelectorAsync(
				   selector: s => new CourseResponseDto
				   {
					   code = s.code,
					   CreatedDate = s.CreatedDate,
					   Credits = s.Credits,
					   Name = s.Name,
					   UpdatedDate = s.UpdatedDate,
					   DepartmentName = s.Department!.Name
				   }, Predecate: (x => x.code == courseCode && x.isActive == false));
			}
			else 
			{
				courseResponseDtos = await _unitOfWork.CourseRepository.GetAllWithSelectorAsync(
				   selector: s => new CourseResponseDto
				   {
					   code = s.code,
					   CreatedDate = s.CreatedDate,
					   Credits = s.Credits,
					   Name = s.Name,
					   UpdatedDate = s.UpdatedDate,
					   DepartmentName = s.Department!.Name
				   }, Predecate: (x => x.isActive == false));

            }

			return new ServiceResponse 
			{
				 Data = courseResponseDtos,
				 Message = "Courses Was Received successfully",
				 StatusCode = 200,
				 Success = true
				 
			};
		}

        public async Task<ServiceResponse> UpdateCourseServiceAsync(int courseId, CourseUpdateRequestDto courseRequestDto)
        {
			var courseModel = await _unitOfWork.CourseRepository.GetByIdAsync(courseId);

			if (courseModel is not null)
			{

				if (courseRequestDto.Name is not null)
					courseModel.Name = courseRequestDto.Name!;

				if (courseRequestDto.code is not null)
					courseModel.code = courseRequestDto.code!;

				if (courseRequestDto.Credits is not null)
					courseModel.Credits = courseRequestDto.Credits ?? 0;

				if (courseRequestDto.DepartmentId is not null)
					courseModel.DepartmentId = courseRequestDto.DepartmentId ?? 0;

				if (courseRequestDto.Description is not null)
					courseModel.Description = courseModel.Description;

				await _unitOfWork.SaveAsync();

				return new ServiceResponse
				{
                    Data = null,
                    Message = "Courses Was Updated successfully",
                    StatusCode = 200,
                    Success = true
                };
			}

            return new ServiceResponse
            {
                Data = null,
                Message = "Courses doesnot exist",
                StatusCode = 404,
                Success = true
            };
        }
    }
}
