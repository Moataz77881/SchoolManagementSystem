using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.CourseDTOs
{
    public class CourseRequestDto
    {
        public string Name { get; set; }
        public string code { get; set; }
        public string? Description { get; set; }
        public int DepartmentId { get; set; }
        public int Credits { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
    }
}
