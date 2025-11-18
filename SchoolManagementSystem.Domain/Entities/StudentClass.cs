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
	public class StudentClass
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("ApplicationUser")]
		public Guid StudentId { get; set; }
		public ApplicationUser? ApplicationUser { get; set; }
		[ForeignKey("Class")]
		public int ClassId { get; set; }
		public Class? Class { get; set; }
		public DateTime EnrollmentDate { get; set; }
	}
}
