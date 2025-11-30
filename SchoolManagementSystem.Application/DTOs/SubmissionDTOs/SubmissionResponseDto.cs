using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.SubmissionDTOs
{
    public class SubmissionResponseDto
    {
        public string AssignmentTitle { get; set; }
        public DateTime SubmittedDate { get; set; }
        public float? Grade { get; set; }
        public string? Remarkes { get; set; }
        public string? TeacherName { get; set; }
    }
}
