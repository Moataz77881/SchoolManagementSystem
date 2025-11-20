using SchoolManagementSystem.Application.DTOs.CourseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.DepartmentDTOs
{
	public class DepartmentUpdateRequestDto
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? HeadOfDepartmentId { get; set; }
		
	}
}
