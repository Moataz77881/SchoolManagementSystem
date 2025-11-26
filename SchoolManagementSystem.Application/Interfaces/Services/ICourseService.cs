using SchoolManagementSystem.Application.DTOs.CourseDTOs;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.Services
{
	public interface ICourseService 
	{
		public Task<ServiceResponse> getAllCourseServiceAsync(string? courseCode);
		public Task<ServiceResponse> CreateCourseServiceAsync(List<CourseRequestDto> courseRequestDto);
		public Task<ServiceResponse> UpdateCourseServiceAsync(int courseId, CourseUpdateRequestDto courseRequestDto);
		public Task<ServiceResponse> DeleteCourses(List<int> courseId);
	}

}
