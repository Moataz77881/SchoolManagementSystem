using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Entities.AuthEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.StudentClassDTOs
{
    public class StudentClassResponseDto
    {
        public string Username { get; set; }
        public string ClassName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
