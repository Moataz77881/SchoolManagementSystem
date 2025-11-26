using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Application.DTOs.CourseDTOs;
using SchoolManagementSystem.Application.DTOs.DepartmentDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Entities.AuthEntities;
using SchoolManagementSystem.Infrastructure.Response;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
	public class DepartmentService(IUnitOfWork _unitOfWork, IMapper _mapper, UserManager<ApplicationUser> _userManager) : IDepartmentService
	{
		public async Task<ServiceResponse> CreateDepartmentsServiceAsync(List<DepartmentCreateRequestDto> departmentDto)
		{
			foreach (var d in departmentDto)
			{
				// check if this user Id  exists
				ApplicationUser? user = await _userManager.FindByIdAsync(d.HeadOfDepartmentId);
				if (user is null)

					return new ServiceResponse
					{
						Data = null,
						Message = $"User doesnot exist in system in {d.Name}",
						StatusCode = 404,
						Success = true
					};

				//Validate that the Head oF fepartment is teacher
				if (user.RoleName != "Teacher".ToLower())
					return new ServiceResponse
					{
						Data = null,
						Message = $"Head Of Department must be A Teacher in {d.Name}",
						StatusCode = 400,
						Success = true
					};

			};
			
			//Map a department dto to department model
			var departmentModels = _mapper.Map<List<Department>>(departmentDto);

			await _unitOfWork.DepartmentRepository.AddRangeAsync(departmentModels);
			await _unitOfWork.SaveAsync();

			return new ServiceResponse
			{
				Data = null,
				Message = "Department List Was Added Successfully",
				StatusCode = 200,
				Success = true
			};

		}

		public async Task<ServiceResponse> DeleteDepartmentServiceAsync(int DepartmentId)
		{
			var departmentModel = await _unitOfWork.DepartmentRepository.GetByIdAsync(DepartmentId);

			if (departmentModel is not null)
			{
				_unitOfWork.DepartmentRepository.Delete(departmentModel);
				await _unitOfWork.SaveAsync();
				return new ServiceResponse
				{
					Data = null,
					Message = "Department was Deleted Successfully",
					StatusCode = 200,
					Success = true
				};
			}
			return new ServiceResponse
			{
				Data = null,
				Message = "Department doesnot exist",
				StatusCode = 404,
				Success = true
			};
		}


		public async Task<ServiceResponse> GetAllDepartmentServiceAsync()
		{
			var res = await _unitOfWork.DepartmentRepository.GetAllWithSelectorAsync(
				d => new DepartmentResponseDto
				{
					Id = d.Id,
					CreatedDate = d.CreatedDate,
					Name = d.Name,
					Description = d.Description,
					HeadOfDepartmentName = d.ApplicationUser!.UserName!,
					UpdateDate = d.UpdateDate,
					Courses = d.Courses!.Select(
						c => new CourseResponseDto
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

		public async Task<ServiceResponse> UpdateDepartmentServiceAsync(int departmentId, DepartmentUpdateRequestDto departmentDto)
		{
			var departmentModel = await _unitOfWork.DepartmentRepository.GetByIdAsync(departmentId);

			if (departmentModel == null)
				return new ServiceResponse
				{
					Data = null,
					Message = "Department doesnot exist",
					StatusCode = 404,
					Success = true
				};

			departmentModel.Name = departmentDto.Name!;
			departmentModel.Description = departmentDto.Description;
			departmentModel.UpdateDate = DateTime.Now;

			// check if this user Id  exists
			ApplicationUser? user = await _userManager.FindByIdAsync(departmentDto.HeadOfDepartmentId!);
			if ( user is not null && user.RoleName == "teacher")
			{
				departmentModel.HeadOfDepartmentId = departmentDto.HeadOfDepartmentId!;

			}
			else 
			{
				return new ServiceResponse
				{
					Data = null,
					Message = "User doesnot exist in system",
					StatusCode = 404,
					Success = true
				};
			}

			await _unitOfWork.SaveAsync();
			
			return new ServiceResponse
			{
				Data = null,
				Message = "Department was Updated Successfully",
				StatusCode = 200,
				Success = true
			};

		}
	}
}
