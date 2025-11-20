using SchoolManagementSystem.Application.DTOs.CourseDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
	public class CourseService(IUnitOfWork _unitOfWork) : ICourseService
	{
		public async Task<ServiceResponse> getAllCourseServiceAsync(string courseCode)
		{
		 	var courses = await _unitOfWork.CourseRepository.GetAllWithSelectorAsync(
				selector: s=> new CourseDto 
				{
					code = s.code,
					CreatedDate = s.CreatedDate,
					Credits = s.Credits,
					Name = s.Name,
					UpdatedDate = s.UpdatedDate,
					DepartmentName = s.Department!.Name
				},Predecate:(x=>x.code == courseCode));

			return new ServiceResponse 
			{
				 Data = courses,
				 Message = "Courses Received successfully",
				 StatusCode = 200,
				 Success = true
				 
			};
		}
	}
}
