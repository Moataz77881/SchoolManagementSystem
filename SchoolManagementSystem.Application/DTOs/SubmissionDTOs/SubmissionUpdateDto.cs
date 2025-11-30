using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.SubmissionDTOs
{
    public class SubmissionUpdateDto
    {
        public float? Grade { get; set; }
        public string? Remarkes { get; set; }
        [JsonIgnore]
        public string? GradedByTeacherId { get; set; }
    }
}
