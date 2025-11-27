using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.AssignmentDTOs
{
    public class AssignmentRequestDto
    {
        public int ClassId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public string? CreatedByTeacherId { get; set; }
    }
}
