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
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class? Class { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser? Student { get; set; }
        public DateTime Date { get; set; } 
        public string Status { get; set; }
        public string MarkedByTeacherId { get; set; }
        public ApplicationUser? Teacher { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
