using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.AttendanceDTOs
{
    public class AttendanceRequestDto
    {
        public int ClassId { get; set; }
        public string StudentId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string MarkedByTeacherId { get; set; }
        [JsonIgnore]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
