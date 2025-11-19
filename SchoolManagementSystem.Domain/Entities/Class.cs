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
	public class Class
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int CourseId {	get; set; }
		public Course? Course { get; set; }
		public string TeacherId { get; set; }
		public ApplicationUser? ApplicationUser { get; set; }
		public int Semester { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime StartDate { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }

		//public ICollection<StudentClass>? StudentClass { get; set; }
  //      public ICollection<Attendance>? Attendances { get; set; }
  //      public ICollection<Assignment>? Assignments { get; set; }

    }
}
