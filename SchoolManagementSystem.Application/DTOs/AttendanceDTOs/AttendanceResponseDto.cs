using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.AttendanceDTOs
{
    public class AttendanceResponseDto
    {
        public int ClassId { get; set; }
        public string StudentName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string TeacherName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
