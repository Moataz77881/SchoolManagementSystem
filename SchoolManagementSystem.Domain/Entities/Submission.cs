using SchoolManagementSystem.Domain.Entities.AuthEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Submission
    {
        [Key]
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public Assignment? Assignment { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser? Student { get; set; }
        public DateTime SubmittedDate { get; set; } = DateTime.Now;
        public string FileUrl { get; set; }
        public float? Grade { get; set; }
        public string? GradedByTeacherId { get; set; }
        public ApplicationUser? Teacher{ get; set; }
        public string? Remarkes { get; set; }
    }
}
