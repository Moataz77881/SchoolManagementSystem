using AutoMapper;
using SchoolManagementSystem.Application.DTOs.AssignmentDTOs;
using SchoolManagementSystem.Application.DTOs.AttendanceDTOs;
using SchoolManagementSystem.Application.DTOs.ClassDto;
using SchoolManagementSystem.Application.DTOs.CourseDTOs;
using SchoolManagementSystem.Application.DTOs.DepartmentDTOs;
using SchoolManagementSystem.Application.DTOs.SubmissionDTOs;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile() 
		{
			CreateMap<DepartmentResponseDto, Department>().ReverseMap();
			CreateMap<DepartmentUpdateRequestDto, Department>().ReverseMap();
			CreateMap<DepartmentCreateRequestDto, Department>().ReverseMap();
			CreateMap<Course, CourseRequestDto>().ReverseMap();
			CreateMap<Class, ClassRequestDto>().ReverseMap();
			CreateMap<Attendance, AttendanceRequestDto>().ReverseMap();
			CreateMap<AssignmentRequestDto, Assignment>().ReverseMap();
			CreateMap<Submission, SubmissionRequestDto>().ReverseMap();
		}
	}
}
