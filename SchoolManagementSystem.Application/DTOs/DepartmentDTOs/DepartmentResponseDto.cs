using SchoolManagementSystem.Application.DTOs.CourseDTOs;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.DepartmentDTOs
{
    public class DepartmentResponseDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
        public string? Description { get; set; }
        public string HeadOfDepartmentName  { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<CourseResponseDto>? Courses { get; set; }
    }
}
