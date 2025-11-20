using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.DepartmentDTOs
{
	public class DepartmentCreateRequestDto
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public string HeadOfDepartmentId { get; set; }
		[JsonIgnore]
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		
	}
}
