using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.StudentClassDTOs
{
    public class StudentClassRequestDto
    {
        public string StudentId { get; set; }
        public int ClassId { get; set; }
        [JsonIgnore]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    }
}
