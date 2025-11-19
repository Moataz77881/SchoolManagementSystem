using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.CourseDTOs
{
    public class CourseDto
    {
        public string Name { get; set; }
        public string code { get; set; }
        public int Credits { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
