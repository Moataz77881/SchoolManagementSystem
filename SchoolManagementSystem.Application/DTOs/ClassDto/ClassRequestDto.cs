using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.ClassDto
{
    public class ClassRequestDto
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public string TeacherId { get; set; }
        public int Semester { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public bool IsActive { get; set; } = false;
    }
}
