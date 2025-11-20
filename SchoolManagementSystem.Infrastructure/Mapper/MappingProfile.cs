using AutoMapper;
using SchoolManagementSystem.Application.DTOs.DepartmentDTOs;
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

		}
	}
}
